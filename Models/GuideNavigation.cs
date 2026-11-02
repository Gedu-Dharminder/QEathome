namespace QEatHome.Models;

/// <summary>
/// The ordered list of guide sections. Change the order or labels here and the
/// navigation, menu, footer links and previous/next buttons all update.
/// </summary>
public static class GuideNavigation
{
    public const string BasePath = "/qe-at-home";

    public static IReadOnlyList<GuideSection> Sections { get; } = new List<GuideSection>
    {
        new("welcome",       "Welcome",       "Distance Learning Guide"),
        new("how-it-works",  "How It Works",  "How Distance Learning Works"),
        new("pre-prep",      "Pre-Prep",      "Pre-Prep"),
        new("prep",          "Prep",          "Prep School"),
        new("senior",        "Senior",        "Senior School"),
        new("flourish",      "Flourish",      "QE Flourish During Distance Learning"),
        new("elevate",       "Elevate",       "QE Elevate"),
        new("online-safety", "Online Safety", "Wellbeing, Safeguarding and Online Safety"),
        new("contacts",      "Contacts",      "Partnership and Communication"),
    };

    public static GuideSection? Find(string? slug) =>
        Sections.FirstOrDefault(s => string.Equals(s.Slug, slug, StringComparison.OrdinalIgnoreCase));

    public static string UrlFor(GuideSection section) =>
        section.Slug == "welcome" ? BasePath : $"{BasePath}/{section.Slug}";
}
