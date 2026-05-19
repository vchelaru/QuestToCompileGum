//Code for UpgradeButton (BubbleGumTheme/Controls/Button)
using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using GumRuntime;
using MonoGameGum;
using MonoGameGum.GueDeriving;
using QuestToCompileGum.Components.BubbleGumTheme.Controls;
using RenderingLibrary.Graphics;
using System.Linq;
namespace QuestToCompileGum.Components;
partial class UpgradeButton : Button
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("UpgradeButton");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named UpgradeButton - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new UpgradeButton(visual);
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(UpgradeButton)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("UpgradeButton", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public Label CostTextInstance { get; protected set; }
    public Label SubTextInstance { get; protected set; }
    public RoundedRectangleRuntime RoundedRectangleInstance { get; protected set; }

    public string CostText
    {
        get => CostTextInstance.Text;
        set => CostTextInstance.Text = value;
    }

    public string SubText
    {
        get => SubTextInstance.Text;
        set => SubTextInstance.Text = value;
    }

    public UpgradeButton(InteractiveGue visual) : base(visual)
    {
    }
    public UpgradeButton()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        CostTextInstance = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<Label>(this.Visual,"CostTextInstance");
        SubTextInstance = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<Label>(this.Visual,"SubTextInstance");
        RoundedRectangleInstance = this.Visual?.GetGraphicalUiElementByName("RoundedRectangleInstance") as global::MonoGameGum.GueDeriving.RoundedRectangleRuntime;
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
