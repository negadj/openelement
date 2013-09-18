Imports System.ComponentModel
Imports System.Drawing.Design

Imports Newtonsoft.Json

Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Common.Attributes.EditListOf
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.LinksManager

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Containers

    <Serializable> _
    Public Class WEAccordionGroup

        #Region "Fields"

        ''' <summary>
        ''' Secondary title displayed on top
        ''' </summary>
        ''' <remarks></remarks>
        Private _AlternateTitle As LocalizableString
        Private _Description As LocalizableString

        ''' <summary>
        ''' closed panel icon
        ''' </summary>
        ''' <remarks></remarks>
        Private _IconOff As Link

        ''' <summary>
        ''' opened panel icon
        ''' </summary>
        ''' <remarks></remarks>
        Private _IconOn As Link

        ''' <summary>
        ''' panel unique id
        ''' </summary>
        ''' <remarks></remarks>
        Private _ID As String

        ''' <summary>
        ''' Panel's title displayed on top
        ''' </summary>
        ''' <remarks></remarks>
        Private _Title As LocalizableString

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal id As String)
            _ID = id
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        LocalizableNameAtt("_N108"), _
        LocalizableDescAtt("_D108"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element), _
        JsonIgnore> _
        Public Property AlternateTitle() As LocalizableString
            Get
                If _AlternateTitle Is Nothing Then _AlternateTitle = New LocalizableString("")
                Return _AlternateTitle
            End Get
            Set(ByVal value As LocalizableString)
                _AlternateTitle = value
            End Set
        End Property

        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        LocalizableNameAtt("_N107"), _
        LocalizableDescAtt("_D107"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element), _
        JsonIgnore> _
        Public Property Description() As LocalizableString
            Get
                If _Description Is Nothing Then _Description = New LocalizableString(LocalizablePropertyDefaultValue._0020) '"Description du groupe"
                Return _Description
            End Get
            Set(ByVal value As LocalizableString)
                _Description = value
            End Set
        End Property

        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        LocalizableNameAtt("_N104"), _
        LocalizableDescAtt("_D104"), _
        Editor(GetType(UITypeLinkFile), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.ElementWithCss), _
        ConfigBiblio(True, False, False, False, False)> _
        Public Property IconOff() As Link
            Get
                If _IconOff Is Nothing Then _IconOff = New Link
                Return _IconOff
            End Get
            Set(ByVal value As Link)
                _IconOff = value
            End Set
        End Property

        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        LocalizableNameAtt("_N105"), _
        LocalizableDescAtt("_D105"), _
        Editor(GetType(UITypeLinkFile), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.ElementWithCss), _
        ConfigBiblio(True, False, False, False, False), _
        ShowColumn(ShowColumn.EnuRepositoryType.RepositoryItemPictureEdit, 30, 30)> _
        Public Property IconOn() As Link
            Get
                If _IconOn Is Nothing Then _IconOn = New Link
                Return _IconOn
            End Get
            Set(ByVal value As Link)
                _IconOn = value
            End Set
        End Property

        <Browsable(False)> _
        Public Property ID() As String
            Get
                Return _ID
            End Get
            Set(ByVal value As String)
                _ID = value
            End Set
        End Property

        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        LocalizableNameAtt("_N103"), _
        LocalizableDescAtt("_D103"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element), _
        ShowColumn, _
        JsonIgnore> _
        Public Property Title() As LocalizableString
            Get
                If _Title Is Nothing Then _Title = New LocalizableString(LocalizablePropertyDefaultValue._0019) 'Titre du groupe
                Return _Title
            End Get
            Set(ByVal value As LocalizableString)
                _Title = value
            End Set
        End Property

        #End Region 'Properties

    End Class

End Namespace

