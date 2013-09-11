Imports System.ComponentModel
Imports openElement.WebElement

Namespace Elements.Form

    ''' <summary>
    ''' listbox generic class
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WEListBoxItem
        Private _Name As LocalizableString
        Private _Value As LocalizableString
        Private _Selected As Boolean

#Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N007"), _
        Ressource.localizable.LocalizableDescAtt("_D007"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.EditListOf.ShowColumn()> _
        Public Property Name() As LocalizableString
            Get
                If _Name Is Nothing Then _Name = New LocalizableString(My.Resources.text.LocalizablePropertyDefaultValue._0008)
                Return _Name
            End Get
            Set(ByVal value As LocalizableString)
                _Name = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N075"), _
        Ressource.localizable.LocalizableDescAtt("_D075"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.EditListOf.ShowColumn()> _
        Public Property Value() As LocalizableString
            Get
                If _Value Is Nothing Then _Value = New LocalizableString(My.Resources.text.LocalizablePropertyDefaultValue._0009)
                Return _Value
            End Get
            Set(ByVal value As LocalizableString)
                _Value = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N209"), _
        Ressource.localizable.LocalizableDescAtt("_D209"), _
        Common.Attributes.EditListOf.ShowColumn(Common.Attributes.EditListOf.ShowColumn.ENURepositoryType.RepositoryItemCheckEdit, Common.Attributes.EditListOf.ShowColumn.EnuCheckStyle.Radio)> _
        Public Property Selected() As Boolean
            Get
                Return _Selected
            End Get
            Set(ByVal value As Boolean)
                _Selected = value
            End Set
        End Property
#End Region

        Public Sub New()
        End Sub

        Public Sub New(ByVal Selected As Boolean)
            _Selected = Selected
        End Sub


    End Class

End Namespace