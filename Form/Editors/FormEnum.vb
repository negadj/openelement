Imports System.ComponentModel

Imports WebElement.Elements.Form.Editors.Converter

Namespace Elements.Form.Editors

    #Region "Enumerations"

    Public Enum RadioButtonDisposition As Short
        VerticalAlign = 0
        Vertical = 1
        Horizontal = 2
    End Enum

    <TypeConverter(GetType(TConvTextAreaScrollOverFlow))> _
    Public Enum TextAreaScrollOverFlow As Short
        Auto = 0
        Scroll = 1
        Hidden = 2
    End Enum

    'Liste de tous les Enum génériques utiser dans le dossier Forms
    <TypeConverter(GetType(TConvTextBoxEnumTextPosition))> _
    Public Enum TextPosition As Short
        Lefttop = 0
        Leftmiddle = 1
        Leftbottom = 2
        Top = 3
        Righttop = 4
        Rightmiddle = 5
        Rightbottom = 6
        Bottom = 7
    End Enum

    <TypeConverter(GetType(TConvTextBoxEnumTextPositionSimple))> _
    Public Enum TextPositionSimple As Short
        Left = 0
        Top = 1
        Right = 2
        Bottom = 3
    End Enum

    #End Region 'Enumerations

End Namespace

