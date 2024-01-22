# Markdown CMS

[![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-2.1-4baaaa.svg)](/.github/CODE_OF_CONDUCT.md)

Markdown CMS is a Nuget package that let's you use GitHub hosted markdown files in a simple web site.

## Should I use Markdown CMS

Maybe.

- Do you have 1000s or 100s of pages? Probably not.
- Do you have a `real CMS` in placed today? Probably not.
- Do you care about `pixle level placement`? Probably not.
- Do you have a few pages like technical instructions? That's why I built it.
- Do you have multiple instances, perhaps deployed by multiple customers, that need different content? That's why I built it.

## See it in action

- A quick example is available [here](https://res-edge.com)
  - We wanted each of our customers to be able to quickly update their documentation
  - We wanted it to look "nice". Doesn't have to be "perfect".
- The default content is [here](https://github.com/cse-labs/res-edge-labs/tree/main/docs)
  - `home.md` gets rendered in the main frame
  - `links.md` gets rendered in the `More Information` frame
  - Our whitepaper and license agreement get rendered in the main frame if you click on the links
- It's fast because we cache the MD and HTML content
- If something like that meets your needs, please try it out and give me feedback
- If not, thanks for dropping by

## Quick Start

- Create a Codespace from this repo
- `dotnet run`
- `code Program.cs`

## Using the HTML

The HTML is generally usable after the conversion. Two things that need to be dealt with are `images` and `links to other markdown files`.

The first step to dealing with these issues effectively is to make sure you have standards in place for how to specify links and images in your markdown. For example, GitHub will render the following links correctly `./images/pb.jpg`, `images/pb.jpg`, and `/docs/images/pb.jpg`. The same is true for links to other markdown: `contact.md`, `./contact.md`, and `/docs/contact.md` are all valid.

Using the full path (`/docs/images/pb.jpg`) has the advantage of still working if you move your md file from the root to a directory. `./images/pb.jpg` seems to be very common as well. I recommend standardizing on one or the other.

Whatever you choose, choose one so that you can replace the HTML easily. Because the HTML is generated from the markdown files (using `Markdig`), the HTML is very clean. It's easy to search on `"./images/` and safely replace it.

You may also have the need to add classes to your HTML so that it renders correctly in your site. For example, you might want to replace `<h1>` with `<h3 class='card-title text-primary'>`.

This is pretty easy to do in C#

```csharp

html = html.Replace("<h1>", "<h3 class='card-title text-primary'>").Replace("</h1>", "</h3>");

```

One of the values of Markdown CMS is it caches the file from GitHub and the generated HTML. To customize the HTML that is created and cached, do the following.

```csharp

public class Program
{
    private static async Task Main
    {
        // set the content GitHub repository
        MdContent.ContentRepo = "bartr/markdowncms";

        // add your custom function(s) - in order!
        MdContent.AddHtmlFunction(ReplaceH1s);

        // your other code
    }

    // custom HTML Function
    private static string ReplaceH1s(string html)
    {
        return html.Replace("<h1>", "<h3 class='card-title text-primary'>").Replace("</h1>", "</h3>");
    }

```

If your markdown files are not standardized, you will get a lot of render and navagation errors. They are easy to fix, but if you can't drive standards, Markdown CMS won't be a good experience. It's pretty easy with a few documents. Lots of documents, modified by lots of people is more problematic.

## Using in your project

## Install MarkdownCms from Nuget

- `dotnet add package MarkdownCms --version 0.1.1`

Open Program.cs for an example

- `code Program.cs`

## Support

This project uses GitHub Issues to track bugs and feature requests. Please search the existing issues before filing new issues to avoid duplicates.  For new issues, file your bug or feature request as a new issue.

For help and questions about using this project, please open a GitHub issue.

## Contributing

This project welcomes contributions and suggestions. Please see [contributing](.github/CONTRIBUTING.md) for more details.

This project has adopted the [Contributor Covenant Code of Conduct](https://www.contributor-covenant.org/version/2/1/code_of_conduct.html). Please see [our code of conduct](.github/CODE_OF_CONDUCT.md) for more details.

## Trademarks

This project may contain trademarks or logos for projects, products, or services. Any use of third-party trademarks or logos are subject to those third-party's policies.
