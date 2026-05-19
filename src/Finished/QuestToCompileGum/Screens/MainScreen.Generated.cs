//Code for MainScreen
using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using GumRuntime;
using MonoGameGum;
using MonoGameGum.GueDeriving;
using QuestToCompileGum.Components;
using QuestToCompileGum.Components.BubbleGumTheme.Controls;
using RenderingLibrary.Graphics;
using System.Linq;
namespace QuestToCompileGum.Screens;
partial class MainScreen : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("MainScreen");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named MainScreen - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new MainScreen(visual);
            visual.Width = 0;
            visual.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            visual.Height = 0;
            visual.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(MainScreen)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("MainScreen", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public ColoredRectangleRuntime RightBackground { get; protected set; }
    public Label ShopHeader { get; protected set; }
    public ColoredRectangleRuntime Separator { get; protected set; }
    public UpgradeButton UpgradeClickButton { get; protected set; }
    public UpgradeButton AutoClickButton { get; protected set; }
    public Label ScoreLabel { get; protected set; }
    public ContainerRuntime UpgradeStack { get; protected set; }
    public RoundedRectangleRuntime LeftBackground { get; protected set; }
    public ColoredRectangleRuntime Divider { get; protected set; }
    public Button BigButton { get; protected set; }
    public Label ScoreValue { get; protected set; }
    public Label ScoreSubtext { get; protected set; }
    public ContainerRuntime ScoreContainer { get; protected set; }
    public ContainerRuntime LeftSidePanel { get; protected set; }
    public ContainerRuntime RightSidePanel { get; protected set; }

    public MainScreen(InteractiveGue visual) : base(visual)
    {
    }
    public MainScreen()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        RightBackground = this.Visual?.GetGraphicalUiElementByName("RightBackground") as global::MonoGameGum.GueDeriving.ColoredRectangleRuntime;
        ShopHeader = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<Label>(this.Visual,"ShopHeader");
        Separator = this.Visual?.GetGraphicalUiElementByName("Separator") as global::MonoGameGum.GueDeriving.ColoredRectangleRuntime;
        UpgradeClickButton = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<UpgradeButton>(this.Visual,"UpgradeClickButton");
        AutoClickButton = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<UpgradeButton>(this.Visual,"AutoClickButton");
        ScoreLabel = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<Label>(this.Visual,"ScoreLabel");
        UpgradeStack = this.Visual?.GetGraphicalUiElementByName("UpgradeStack") as global::MonoGameGum.GueDeriving.ContainerRuntime;
        LeftBackground = this.Visual?.GetGraphicalUiElementByName("LeftBackground") as global::MonoGameGum.GueDeriving.RoundedRectangleRuntime;
        Divider = this.Visual?.GetGraphicalUiElementByName("Divider") as global::MonoGameGum.GueDeriving.ColoredRectangleRuntime;
        BigButton = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<Button>(this.Visual,"BigButton");
        ScoreValue = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<Label>(this.Visual,"ScoreValue");
        ScoreSubtext = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<Label>(this.Visual,"ScoreSubtext");
        ScoreContainer = this.Visual?.GetGraphicalUiElementByName("ScoreContainer") as global::MonoGameGum.GueDeriving.ContainerRuntime;
        LeftSidePanel = this.Visual?.GetGraphicalUiElementByName("LeftSidePanel") as global::MonoGameGum.GueDeriving.ContainerRuntime;
        RightSidePanel = this.Visual?.GetGraphicalUiElementByName("RightSidePanel") as global::MonoGameGum.GueDeriving.ContainerRuntime;
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
