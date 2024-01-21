# MarkdownCms

[![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-2.1-4baaaa.svg)](.github/code_of_conduct.md)

Markdown CMS is a library that let's you use GitHub hosted markdown files in your web site.

## Quick Start

- Clone this repo
- `dotnet run`

## Install MarkdownCms from Nuget

- `dotnet add package MarkdownCms --version 0.1.0`

## Use MarkdownCms

- `using MarkdownCms;`

## Set Repo Information

```csharp

// set the content GitHub repository
MdContent.ContentRepo = "bartr/markdowncms";

// change from default values if desired
// MdContent.ContentBranch = "main";
// MdContent.ContentPath = "docs";

```

## Get Markdown from GitHub

```csharp

ContentItem? home = await MdContent.GetContent("home.md");
string md = await MdContent.GetMd("home.md");
string html = await MdContent.GetHtml("home.md");

// this file will fail and print two log messages
_ = await MdContent.GetMd("foo.md");


```

## Support

This project uses GitHub Issues to track bugs and feature requests. Please search the existing issues before filing new issues to avoid duplicates.  For new issues, file your bug or feature request as a new issue.

For help and questions about using this project, please open a GitHub issue.

## Contributing

This project welcomes contributions and suggestions. Please see [contributing](.github/CONTRIBUTING.md) for more details.

This project has adopted the [Contributor Covenant Code of Conduct](https://www.contributor-covenant.org/version/2/1/code_of_conduct.html). Please see [our code of conduct](.github/CODE_OF_CONDUCT.md) for more details.

## Trademarks

This project may contain trademarks or logos for projects, products, or services. Any use of third-party trademarks or logos are subject to those third-party's policies.
