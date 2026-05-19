//Code for FloatingLabel (BubbleGumTheme/Controls/Label)
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
partial class FloatingLabel : Label
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("FloatingLabel");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named FloatingLabel - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new FloatingLabel(visual);
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(FloatingLabel)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("FloatingLabel", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }

    public FloatingLabel(InteractiveGue visual) : base(visual)
    {
    }
    public FloatingLabel()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
