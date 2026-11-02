namespace QEatHome.Models;

/// <summary>
/// One section of the QE@Home guide. Each section has its own page and view.
/// </summary>
/// <param name="Slug">URL segment, e.g. "pre-prep". Must match a view in Views/QEatHome.</param>
/// <param name="NavTitle">Short label shown in the section navigation.</param>
/// <param name="PageTitle">Full title used in the browser tab.</param>
public sealed record GuideSection(string Slug, string NavTitle, string PageTitle);
