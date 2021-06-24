using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.DocAsCode.Common;
using Microsoft.DocAsCode.Dfm;
using Microsoft.DocAsCode.MarkdownLite;

namespace Caravela.Documentation.DfmExtensions
{
    public class SampleRendererPart : DfmCustomizedRendererPartBase<IMarkdownRenderer, DfmIncludeBlockToken,
        MarkdownBlockContext>
    {
        private static int nextId = 1;
        
        public override string Name => nameof(SampleRendererPart);

        public override bool Match(IMarkdownRenderer renderer, DfmIncludeBlockToken token, MarkdownBlockContext context)
        {
            return TryParseToken(token, out _);
        }

        private static string HtmlEncode(string s)
        {
            var stringBuilder = new StringBuilder(s.Length);

            foreach (var c in s)
                switch (c)
                {
                    case '<':
                        stringBuilder.Append("&lt;");

                        break;

                    case '>':
                        stringBuilder.Append("&gt;");

                        break;

                    case '&':
                        stringBuilder.Append("&amp;");

                        break;

                    default:
                        stringBuilder.Append(c);

                        break;
                }

            return stringBuilder.ToString();
        }

        private static bool TryParseToken(DfmIncludeBlockToken token,
            out ( string FilePath, string Fragment, NameValueCollection Query ) parsed)
        {
            
            var targetFileName = UriUtility.GetPath(token.Src);
            if (!targetFileName.EndsWith(".cs"))
            {
                parsed = default;
                return false;
            }

            

            var parameters = new NameValueCollection();

            if (UriUtility.HasQueryString(token.Src))
            {
                foreach (var part in UriUtility.GetQueryString(token.Src).Split('&'))
                {
                    var nameValuePair = part.Split('=');
                    
                    parameters.Add(nameValuePair[0], nameValuePair.Length > 1 ? nameValuePair[1] : null);
                }
            }

            parsed = (targetFileName, UriUtility.GetFragment(token.Src), parameters);

            return true;
        }

        private static string FindParentDirectory(string directory, Predicate<string> predicate)
        {
            if (directory == null) return null;

            if (predicate(directory))
            {
                return directory;
            }
            else
            {
                var parentDirectory = Path.GetDirectoryName(directory);

                return FindParentDirectory(parentDirectory, predicate);
            }
        }

        public override StringBuffer Render(IMarkdownRenderer renderer, DfmIncludeBlockToken token,
            MarkdownBlockContext context)
        {
            TryParseToken(token, out var source);

            var referencingFile =
                Path.GetFullPath(Path.Combine((string) context.Variables["BaseFolder"], token.SourceInfo.File));

            var shortFileNameWithoutExtension = Path.GetFileNameWithoutExtension(source.FilePath);
            var targetPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(referencingFile), source.FilePath));
            var transformedPath = Path.ChangeExtension(targetPath, ".t.cs");
            var aspectPath = Path.ChangeExtension(targetPath, ".Aspect.cs");

            // Find the directories.
            var projectDir = FindParentDirectory(Path.GetDirectoryName(targetPath),
                directory => Directory.GetFiles(directory, "*.csproj").Length > 0);
            var gitDirectory = FindParentDirectory(Path.GetDirectoryName(targetPath),
                directory => Directory.Exists(Path.Combine(directory, ".git")));

            var targetPathRelativeToProjectDir = GetRelativePath(projectDir, targetPath);
            var sourceDirectoryRelativeToGitDir = GetRelativePath(gitDirectory, Path.GetDirectoryName(targetPath));

            var aspectHtmlPath = Path.GetFullPath(Path.Combine(projectDir, "obj", "highlighted",
                Path.ChangeExtension(targetPathRelativeToProjectDir, ".Aspect.t.html")));
            var targetHtmlPath = Path.GetFullPath(Path.Combine(projectDir, "obj", "highlighted",
                Path.ChangeExtension(targetPathRelativeToProjectDir, ".t.html")));

            const string gitBranch = "release/0.3";
            const string gitHubProjectPath = "https://github.com/postsharp/Caravela/blob/" + gitBranch;

            if (File.Exists(aspectPath))
            {
                // Create the tab group with the aspect, target, and transformed code.

                var targetSrc = File.ReadAllText(targetPath);
                var aspectSrc = File.ReadAllText(aspectHtmlPath);
                var transformedSrc = File.ReadAllText(transformedPath);

                

                var template = @"
<div class=""see-on-github tabbed""><a href=""GIT_URL"">See on GitHub</a></div>
<div class=""tabGroup"">
    <ul>
        <li>
            <a href=""#tabpanel_IDENTIFIER_aspect"">Aspect Code</a>
        </li>
        <li>
            <a href=""#tabpanel_IDENTIFIER_target"">Target Code</a>
        </li>
        <li>
            <a href=""#tabpanel_IDENTIFIER_transformed"">Transformed Code</a>
        </li>
    </ul>
    <div id=""tabpanel_IDENTIFIER_aspect"">
        ASPECT_CODE
    </div>
    <div id=""tabpanel_IDENTIFIER_target"">
        <pre><code class=""lang-csharp"" name=""Target Code"">TARGET_CODE</code></pre>
    </div>
    <div id=""tabpanel_IDENTIFIER_transformed"">
        <pre><code class=""lang-csharp"" name=""Main"">TRANSFORMED_CODE</code></pre>
    </div>
</div>
";

                var gitUrl = gitHubProjectPath + "/" + sourceDirectoryRelativeToGitDir + "/" +
                                   shortFileNameWithoutExtension + ".Aspect.cs";
                return template
                    .Replace("IDENTIFIER", Interlocked.Increment(ref nextId).ToString())
                    .Replace("ASPECT_CODE", aspectSrc)
                    .Replace("TARGET_CODE", HtmlEncode(targetSrc))
                    .Replace("TRANSFORMED_CODE", HtmlEncode(transformedSrc))
                    .Replace("GIT_URL",
                        gitUrl);
            }
            else
            {
                var gitUrl = gitHubProjectPath + "/" + sourceDirectoryRelativeToGitDir + "/" +
                                   shortFileNameWithoutExtension + ".cs";

                var gitHubLink = @"<div class=""see-on-github""><a href=""GIT_URL"">See on GitHub</a></div>"
                    .Replace("GIT_URL", gitUrl);
                
                if (File.Exists(targetHtmlPath))
                {
                    // Write the syntax-highlighted HTML instead.

                    var html = File.ReadAllText(targetHtmlPath);
                    return gitHubLink + html;
                }
                else
                {
                    return gitHubLink + 
                        @"<pre><code class=""lang-csharp"" name=""NAME"">TARGET_CODE</code></pre>"
                        .Replace("TARGET_CODE", File.ReadAllText(targetPath))
                        .Replace("GIT_URL", gitUrl)
                        .Replace("NAME", token.Name);
                }
            }
        }
    

        private static string GetRelativePath(string projectDir, string targetPath)
        {
            return new Uri(Path.Combine(projectDir, "_")).MakeRelativeUri(new Uri(targetPath)).ToString();
        }
    }
}