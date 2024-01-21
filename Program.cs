using System;
using System.Threading.Tasks;
using MarkdownCms;

namespace Sample;

class App
{
    public static async Task Main()
    {
        // set the content GitHub repository
        MdContent.ContentRepo = "bartr/markdowncms";

        // change from default values if desired
        // MdContent.ContentBranch = "main";
        // MdContent.ContentPath = "docs";

        ContentItem? home = await MdContent.GetContent("home.md");
        string md = await MdContent.GetMd("home.md");
        string html = await MdContent.GetHtml("home.md");

        // this file will fail and print two log messages
        _ = await MdContent.GetMd("foo.md");

        // give logs time to print
        System.Threading.Thread.Sleep(500);
        
        Console.WriteLine($"\n\nDate: {home!.Date}\n\nMD\n{md}\n\nHTML\n{html}");
    }
}
