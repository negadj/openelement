Imports System.ComponentModel

Namespace Elements.Form.Editors

    'Liste de tous les Enum génériques utiser dans le dossier Forms

    <TypeConverter(GetType(Editors.Converter.TConvTextBoxEnumTextPosition))> _
   Public Enum TextPosition As Short
        lefttop = 0
        leftmiddle = 1
        leftbottom = 2
        top = 3
        righttop = 4
        rightmiddle = 5
        rightbottom = 6
        bottom = 7
    End Enum

    <TypeConverter(GetType(Editors.Converter.TConvTextAreaScrollOverFlow))> _
    Public Enum TextAreaScrollOverFlow As Short
        auto = 0
        scroll = 1
        hidden = 2
    End Enum

    Public Enum RadioButtonDisposition As Short
        verticalAlign = 0
        Vertical = 1
        horizontal = 2
    End Enum

    <TypeConverter(GetType(Editors.Converter.TConvTextBoxEnumTextPositionSimple))> _
    Public Enum TextPositionSimple As Short
        left = 0
        top = 1
        right = 2
        bottom = 3
    End Enum

End Namespace