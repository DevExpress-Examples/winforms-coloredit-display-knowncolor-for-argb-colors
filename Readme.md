<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsApplication78/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication78/Form1.vb))
* [MyColorEdit.cs](./CS/WindowsApplication78/MyColorEdit.cs) (VB: [MyColorEdit.vb](./VB/WindowsApplication78/MyColorEdit.vb))
<!-- default file list end -->
# How to display KnownColor names for ARGB colors in ColorEdit


<p>You can accomplish this task by creating a custom ColorEdit descendant, and overriding the RepositoryItemColorEdit.GetColorDisplayText method. A helper class to convert any color to Known color is also included.</p>

<br/>


