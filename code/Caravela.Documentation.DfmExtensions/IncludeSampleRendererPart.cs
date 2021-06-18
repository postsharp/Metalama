using System.IO;
using System.Text;
using System.Threading;
using Microsoft.DocAsCode.Dfm;
using Microsoft.DocAsCode.MarkdownLite;

namespace Caravela.Documentation.DfmExtensions
{
    public class IncludeSampleRendererPart : DfmCustomizedRendererPartBase<IMarkdownRenderer, DfmIncludeBlockToken, MarkdownBlockContext>
    {
        const string suffix = "#sample";
        private static int nextId = 1;
        
        public override string Name => nameof(IncludeSampleRendererPart);

        public override bool Match(IMarkdownRenderer renderer, DfmIncludeBlockToken token, MarkdownBlockContext context)
        {
            return token.Src.EndsWith(suffix);
        }
        
        private static string HtmlEncode( string s )
        {
            var stringBuilder = new StringBuilder( s.Length );

            foreach ( var c in s )
            {
                switch ( c )
                {
                    case '<':
                        stringBuilder.Append( "&lt;" );

                        break;

                    case '>':
                        stringBuilder.Append( "&gt;" );

                        break;

                    case '&':
                        stringBuilder.Append( "&amp;" );

                        break;

                    default:
                        stringBuilder.Append( c );

                        break;
                }
            }

            return stringBuilder.ToString();
        }

        public override StringBuffer Render(IMarkdownRenderer renderer, DfmIncludeBlockToken token, MarkdownBlockContext context)
        {
            var targetPath = token.Src.Substring(0, token.Src.Length - suffix.Length);
            var aspectPath = Path.ChangeExtension(targetPath, ".Aspect.cs");
            var transformedPath = Path.ChangeExtension(targetPath, ".t.cs");

            var targetSrc = File.ReadAllText(targetPath);
            var aspectSrc = File.ReadAllText(aspectPath);
            var transformedSrc = File.ReadAllText(transformedPath);
            
            
            var template = @"
 <div class=""tabGroup"" id=""tabgroup_IDENTIFIER"">
<ul role=""tablist"">
<li role=""presentation"">
<a href=""#tabpanel_IDENTIFIER_aspect"" role=""tab"" aria-controls=""tabpanel_IDENTIFIER_aspect"" data-tab=""aspect"" tabindex=""0"" aria-selected=""true"">Aspect Code</a>
</li>
<li role=""presentation"">
<a href=""#tabpanel_IDENTIFIER_target"" role=""tab"" aria-controls=""tabpanel_IDENTIFIER_target"" data-tab=""target"" tabindex=""-1"">Target Code</a>
</li>
<li role=""presentation"">
<a href=""#tabpanel_IDENTIFIER_transformed"" role=""tab"" aria-controls=""tabpanel_IDENTIFIER_transformed"" data-tab=""transformed"" tabindex=""-1"">Transformed Code</a>
</li>
</ul>
<section id=""tabpanel_IDENTIFIER_aspect"" role=""tabpanel"" data-tab=""aspect"">
<pre><code class=""lang-csharp"" name=""Aspect Code"">ASPECT_CODE</code></pre></section>
<section id=""tabpanel_IDENTIFIER_target"" role=""tabpanel"" data-tab=""target"" aria-hidden=""true"" hidden=""hidden"">
<pre><code class=""lang-csharp"" name=""Target Code"">TARGET_CODE</code></pre></section>
<section id=""tabpanel_IDENTIFIER_transformed"" role=""tabpanel"" data-tab=""transformed"" aria-hidden=""true"" hidden=""hidden"">
<pre><code class=""lang-csharp"" name=""Main"">TRANSFORMED_CODE</code></pre></section>
";

            StringBuffer sb = template
                .Replace("IDENTIFIER", Interlocked.Increment(ref nextId).ToString())
                .Replace("ASPECT_CODE",  HtmlEncode( aspectSrc) )
                .Replace("TARGET_CODE", HtmlEncode(targetSrc))
                .Replace("TRANSFORMED_CODE", HtmlEncode(transformedSrc));
            
                
            return sb;
        }

        private void AppendSection(StringBuffer sb)
        {
            sb.Append()
        }
    }
}