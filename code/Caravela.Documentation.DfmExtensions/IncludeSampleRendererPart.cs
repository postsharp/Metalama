using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.DocAsCode.Dfm;
using Microsoft.DocAsCode.MarkdownLite;

namespace Caravela.Documentation.DfmExtensions
{
    public class IncludeSampleRendererPart : DfmCustomizedRendererPartBase<IMarkdownRenderer, DfmIncludeBlockToken, MarkdownBlockContext>
    {
        const string suffix = "?sample";
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
        
        private static string FindParentDirectory( string directory, Predicate<string> predicate )
        {
            if ( directory == null )
            {
                return null;
            }

            if ( predicate(directory) )
            {
                return directory;
            }
            else
            {
                var parentDirectory = Path.GetDirectoryName( directory );

                return FindParentDirectory( parentDirectory, predicate );
            }
        }

        public override StringBuffer Render(IMarkdownRenderer renderer, DfmIncludeBlockToken token, MarkdownBlockContext context)
        {
            var referencingFile =
                Path.GetFullPath(Path.Combine((string) context.Variables["BaseFolder"], token.SourceInfo.File));
            
            var targetFileName = token.Src.Substring(0, token.Src.Length - suffix.Length);
            var shortFileNameWithoutExtension = Path.GetFileNameWithoutExtension(targetFileName);
            var targetPath = Path.GetFullPath( Path.Combine(Path.GetDirectoryName(referencingFile), targetFileName) );
            var transformedPath = Path.ChangeExtension(targetPath, ".t.cs");

            // For the aspect, look into the rendered html file.
            var projectDir = FindParentDirectory(Path.GetDirectoryName(targetPath), directory => Directory.GetFiles( directory, "*.csproj" ).Length > 0);
            var gitDirectory = FindParentDirectory(Path.GetDirectoryName(targetPath), directory => Directory.Exists(Path.Combine(directory, ".git")));
            
            var targetPathRelativeToProjectDir = GetRelativePath(projectDir, targetPath);
            var sourceDirectoryRelativeToGitDir = GetRelativePath(gitDirectory, Path.GetDirectoryName(targetPath));
            var aspectPath = Path.GetFullPath(Path.Combine(projectDir, "obj", "highlighted",
                Path.ChangeExtension(targetPathRelativeToProjectDir, ".Aspect.t.html")));


            var targetSrc = File.ReadAllText(targetPath);
            var aspectSrc = File.ReadAllText(aspectPath);
            var transformedSrc = File.ReadAllText(transformedPath);
            const string gitBranch = "release/0.3";
            const string gitHubProjectPath = "https://github.com/postsharp/Caravela/blob/" + gitBranch;
            
            
            var template = @"
<a href=""GIT_ASPECT_URL"" class=""see-on-github"">See on GitHub</a>
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
    ASPECT_CODE
    
</section>
<section id=""tabpanel_IDENTIFIER_target"" role=""tabpanel"" data-tab=""target"" aria-hidden=""true"" hidden=""hidden"">
    <pre><code class=""lang-csharp"" name=""Target Code"">TARGET_CODE</code></pre>
</section>
<section id=""tabpanel_IDENTIFIER_transformed"" role=""tabpanel"" data-tab=""transformed"" aria-hidden=""true"" hidden=""hidden"">
    <pre><code class=""lang-csharp"" name=""Main"">TRANSFORMED_CODE</code></pre>
</section>
";

            var gitAspectUrl = gitHubProjectPath + "/" + sourceDirectoryRelativeToGitDir + "/" + shortFileNameWithoutExtension + ".Aspect.cs";
            StringBuffer sb = template
                .Replace("IDENTIFIER", Interlocked.Increment(ref nextId).ToString())
                .Replace("ASPECT_CODE", aspectSrc)
                .Replace("TARGET_CODE", HtmlEncode(targetSrc))
                .Replace("TRANSFORMED_CODE", HtmlEncode(transformedSrc))
                .Replace("GIT_ASPECT_URL",
                    gitAspectUrl);
            
                
            return sb;
        }

        private static string GetRelativePath(string projectDir, string targetPath)
        {
            return new Uri(Path.Combine(projectDir, "_")).MakeRelativeUri(new Uri(targetPath)).ToString();
        }
    }
}