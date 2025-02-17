namespace DocQnA.Presentation.UI.Navigation;

public interface IScreenNavigator
{
    Task NavigateToAsync(ScreenType screenType);
}
