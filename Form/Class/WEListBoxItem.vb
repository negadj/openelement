Imports System.ComponentModel

Imports openElement.WebElement.Common.Attributes.EditListOf
Imports openElement.WebElement.Editors.Converter

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Form

    ''' <summary>
    ''' listbox generic class
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable> _
    Public Class WEListBoxItem

        #Region "Fields"

        Private _Name As LocalizableString
        Private _Selected As Boolean
        Private _Value As LocalizableString

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New()
        End Sub

        Public Sub New(ByVal selected As Boolean)
            _Selected = selected
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        LocalizableNameAtt("_N007"), _
        LocalizableDescAtt("_D007"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        ShowColumn> _
        Public Property Name() As LocalizableString
            Get
                If _Name Is Nothing Then _Name = New LocalizableString(LocalizablePropertyDefaultValue._0008)
                Return _Name
            End Get
            Set(ByVal value As LocalizableString)
                _Name = value
            End Set
        End Property

        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        LocalizableNameAtt("_N209"), _
        LocalizableDescAtt("_D209"), _
        ShowColumn(ShowColumn.EnuRepositoryType.RepositoryItemCheckEdit, ShowColumn.EnuCheckStyle.Radio)> _
        Public Property Selected() As Boolean
            Get
                Return _Selected
            End Get
            Set(ByVal value As Boolean)
                _Selected = value
            End Set
        End Property

        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        LocalizableNameAtt("_N075"), _
        LocalizableDescAtt("_D075"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        ShowColumn> _
        Public Property Value() As LocalizableString
            Get
                If _Value Is Nothing Then _Value = New LocalizableString(LocalizablePropertyDefaultValue._0009)
                Return _Value
            End Get
            Set(ByVal value As LocalizableString)
                _Value = value
            End Set
        End Property

        #End Region 'Properties

    End Class

End Namespace

