using Microsoft.AspNetCore.Mvc;
using QEatHome.Models;

namespace QEatHome.Controllers;

/// <summary>
/// Serves the QE@Home guide, one section per page.
/// GET /qe-at-home            -> Welcome
/// GET /qe-at-home/{slug}     -> the named section, or 404 if it does not exist
/// </summary>
public sealed class QEatHomeController : Controller
{
    [HttpGet]
    public IActionResult Section(string? slug)
    {
        // The old single-page version linked to #checklist; keep that working.
        if (string.Equals(slug, "checklist", StringComparison.OrdinalIgnoreCase))
        {
            return Redirect($"{GuideNavigation.BasePath}/contacts#checklist");
        }

        var section = string.IsNullOrWhiteSpace(slug)
            ? GuideNavigation.Sections[0]
            : GuideNavigation.Find(slug);

        if (section is null)
        {
            return NotFound();
        }

        var sections = GuideNavigation.Sections;
        var index = sections.ToList().IndexOf(section);

        var model = new GuidePageViewModel
        {
            Current = section,
            Previous = index > 0 ? sections[index - 1] : null,
            Next = index < sections.Count - 1 ? sections[index + 1] : null,
        };

        // Views are named after the slug, e.g. Views/QEatHome/pre-prep.cshtml.
        return View(section.Slug, model);
    }
}
