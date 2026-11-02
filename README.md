# QE@Home: distance learning mini-site

Queen Elizabeth's School, Dubai Sports City

This is the QE@Home guide for families as an ASP.NET Core MVC application (C#, .NET 8). It has nine sections, each on its own page:

| URL | Section |
| --- | --- |
| `/qe-at-home` | Welcome |
| `/qe-at-home/how-it-works` | How It Works |
| `/qe-at-home/pre-prep` | Pre-Prep |
| `/qe-at-home/prep` | Prep |
| `/qe-at-home/senior` | Senior |
| `/qe-at-home/flourish` | QE Flourish |
| `/qe-at-home/elevate` | QE Elevate (inclusion) |
| `/qe-at-home/online-safety` | Wellbeing, Safeguarding and Online Safety |
| `/qe-at-home/contacts` | Partnership, Contacts and the Family Checklist (`#checklist`) |

The content has been approved by the school. Please do not change the wording without checking with the Principal's office.

## Running it locally

Requires the .NET 8 SDK.

```
dotnet run
```

Then open the address shown in the console (the site root redirects to `/qe-at-home`).

## Project layout

```
Program.cs                         Routing: /qe-at-home/{slug}
Controllers/QEatHomeController.cs  Picks the section view and builds previous/next links; 404 for unknown sections
Models/GuideNavigation.cs          The ordered list of sections (labels, page titles, URLs)
Models/GuideSection.cs             One section
Models/GuidePageViewModel.cs       Data passed to the layout
Views/Shared/_QEatHomeLayout.cshtml  Masthead, section bar, full-screen menu, previous/next, footer
Views/QEatHome/*.cshtml            One view per section, holding that section's content
wwwroot/qe-at-home/css/qe-at-home.css  All styles
wwwroot/qe-at-home/js/qe-at-home.js    Menu open/close only (no other script)
wwwroot/qe-at-home/img/            Photos and the crest
```

To change a section's wording, edit its view in `Views/QEatHome`. To reorder or rename sections, edit `Models/GuideNavigation.cs`; the navigation, menu, footer links and previous/next buttons all follow from that list.

Note for Razor: an `@` in content text must be written as `@@` (for example `QE@@Home` and email addresses).

## Brand

- Navy `#00142E`
- Gold RGB 186, 152, 99 (`#BA9863`), used for every gold element, including the crest
- Serif: Essonnes (`essonnes-display-regular`), fallback Georgia
- Sans serif: Soleil (`Soleil-Regular`), fallback Arial

The fonts are referenced by the family names the main school website already loads. This project does not include the font files, because they are licensed to the school. When the pages run inside the main website, they will pick up Essonnes and Soleil automatically. When run on their own, they fall back to Georgia and Arial.

## Integrating with the main school website

The main website appears to be built on Umbraco with uSkinned (judging by its stylesheet paths). Suggested approach:

1. **Content.** Either keep the nine section views as Razor partials rendered by a single Umbraco template, or create a "QE@Home Section" document type with a rich-text field and paste each view's HTML into it. The views are plain HTML apart from the `@model` line.
2. **Layout.** Replace `_QEatHomeLayout.cshtml` with the site's own master layout so the real header, navigation and footer are used. Keep the QE@Home section bar (`.subnav`) and previous/next links if possible, as they help parents move between phases.
3. **Styles.** `qe-at-home.css` styles some generic elements (`body`, `h1` to `h4`, `table`, `header.site`, `footer`). If it is loaded inside the main site, wrap the guide's content in a container (for example `<div class="qeathome">`) and prefix the selectors, so they do not affect other pages.
4. **Images.** Paths are absolute (`/qe-at-home/img/...`). Move the images into the Umbraco media library and update the paths, or serve `wwwroot/qe-at-home` as it is.
5. **Address.** Suggested public address: `qedubaisportscity.com/qe-at-home`. The old link `/qe-at-home/checklist` redirects to the checklist on the Contacts page.

## Before publishing

- Several photos show pupils' faces. Please confirm media consent for every pupil shown before the pages go live.
- The site can be published in advance with no menu link, and promoted only if the school moves to distance learning.
