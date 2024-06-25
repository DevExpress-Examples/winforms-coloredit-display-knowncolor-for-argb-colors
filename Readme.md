<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128620656/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1516)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Winforms Color Editor - Display known system colors for ARGB colors

This example creates a custom color editor and overrides the `RepositoryItemColorEdit.GetColorDisplayText` method. The example also uses a helper class to convert a color in any format to a known system color.

![Winforms Color Editor - Display known system colors for ARGB colors](https://raw.githubusercontent.com/DevExpress-Examples/how-to-display-knowncolor-names-for-argb-colors-in-coloredit-e1516/13.1.4%2B/media/winforms-coloredit-custom-color-name.png)

```csharp
public class RepositoryItemMyColorEdit : RepositoryItemColorEdit {
    // ...
    protected override string GetColorDisplayText(Color editValue) {
        object color = editValue;
        ColorHelper.TryConvertToKnownColor(ref color);
        return base.GetColorDisplayText((Color)color);
    }
}
```


## Files to Review

* [Form1.cs](./CS/WindowsApplication78/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication78/Form1.vb))
* [MyColorEdit.cs](./CS/WindowsApplication78/MyColorEdit.cs) (VB: [MyColorEdit.vb](./VB/WindowsApplication78/MyColorEdit.vb))


## Documentation

* [Custom Editors](https://docs.devexpress.com/WindowsForms/4716/controls-and-libraries/editors-and-simple-controls/common-editor-features-and-concepts/custom-editors)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-coloredit-display-knowncolor-for-argb-colors&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-coloredit-display-knowncolor-for-argb-colors&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
