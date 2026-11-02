namespace QEatHome.Models;

/// <summary>
/// Passed to the shared layout so it can render the navigation and the
/// previous/next links for the current section.
/// </summary>
public sealed class GuidePageViewModel
{
    public required GuideSection Current { get; init; }
    public IReadOnlyList<GuideSection> Sections { get; init; } = GuideNavigation.Sections;
    public GuideSection? Previous { get; init; }
    public GuideSection? Next { get; init; }
}
