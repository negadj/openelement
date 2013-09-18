Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.DataType.Enum
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Control
Imports openElement.WebElement.Editors.Converter.Enum
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager
Imports openElement.WebElement.StylesManager.CssItems

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Containers

    <Serializable> _
    Public Class WEAccordion
        Inherits ElementBase

        #Region "Fields"

        ''' <summary>
        ''' list of accordion panel
        ''' </summary>
        ''' <remarks></remarks>
        <ContainsLinks> _
        Private _AccordionGroups As List(Of WEAccordionGroup)

        ''' <summary>
        ''' slow effect
        ''' </summary>
        ''' <remarks></remarks>
        Private _Easing As EnumEasingEffect

        ''' <summary>
        ''' Opening index at the loading page
        ''' </summary>
        ''' <remarks></remarks>
        Private _OpenGroupIndex As Integer = 0

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEAccordion", page, parentID, templateName)

            Dim group1 As New WEAccordionGroup(NewTemplate)
            group1.Title.SetValue(LocalizableFormAndConverter._0156 & " 1")
            Dim group2 As New WEAccordionGroup(NewTemplate)
            group2.Title.SetValue(LocalizableFormAndConverter._0156 & " 2")

            Me.AccordionGroups.Add(group1)
            Me.AccordionGroups.Add(group2)
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N001"), _
        LocalizableDescAtt("_D011"), _
        Editor(GetType(UITypeEditListOf), GetType(UITypeEditor)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property AccordionGroups() As List(Of WEAccordionGroup)
            Get
                If _AccordionGroups Is Nothing Then _AccordionGroups = New List(Of WEAccordionGroup)
                Return _AccordionGroups
            End Get
            Set(ByVal value As List(Of WEAccordionGroup))
                Call UpdateTemplates(_AccordionGroups, value)
                _AccordionGroups = value
            End Set
        End Property

        ''' <summary>
        ''' visual effect
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N232"), _
        LocalizableDescAtt("_D232"), _
        TypeConverter(GetType(TConvEnumEasingEffect)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Easing() As EnumEasingEffect
            Get
                Return _Easing
            End Get
            Set(ByVal value As EnumEasingEffect)
                _Easing = value
            End Set
        End Property

        ''' <summary>
        ''' Export of the effect at js file
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingJs() As String
            Get
                Return _Easing.ToString
            End Get
        End Property

        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public Property OpenGroupIndex() As Integer
            Get
                Return _OpenGroupIndex
            End Get
            Set(ByVal value As Integer)
                _OpenGroupIndex = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
            ByVal accListLS As Dictionary(Of String, LocalizableString), _
            ByVal accListInfo As Dictionary(Of String, String), _
            Optional ByVal onlyNonEmpty As Boolean = True) As Boolean
            Dim r As Boolean = False

            If _AccordionGroups Is Nothing OrElse _AccordionGroups.Count < 1 Then Return r

            Dim cntr As Integer = 0
            For Each item In _AccordionGroups
                cntr += 1
                r = r Or AddLSForTranslationSystem(item.Title, "Group" & cntr.ToString & ".Title", "WEContainers", "Accordion Container", accListLS, accListInfo, onlyNonEmpty)
                r = r Or AddLSForTranslationSystem(item.AlternateTitle, "Group" & cntr.ToString & ".AltTitle", "WEContainers", "Accordion Container", accListLS, accListInfo, onlyNonEmpty)
                r = r Or AddLSForTranslationSystem(item.Description, "Group" & cntr.ToString & ".Description", "WEContainers", "Accordion Container", accListLS, accListInfo, onlyNonEmpty)
            Next
            Return r
        End Function

        Protected Overrides Sub OnDataFromJs(ByVal data As String)
            If data Is Nothing Then Me.OpenGroupIndex = -1 : Exit Sub
            Dim index As Integer = 0
            For Each group As WEAccordionGroup In Me.AccordionGroups
                If group.ID.Equals(data) Then
                    Me.OpenGroupIndex = index
                    Exit Sub
                End If
                index += 1
            Next
            Me.OpenGroupIndex = -1
        End Sub

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As CtlEditListOf.AddButton, ByVal selectedNodeTag As CtlEditListOf.NodeTag) As List(Of Object)
            Dim newObs As New List(Of Object)
            newObs.Add(New WEAccordionGroup(NewTemplate))
            Return newObs
        End Function

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0157
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupContainers"
            info.ToolBoxIco = My.Resources.WEPanel
            info.ToolBoxDescription = LocalizableOpen._0158
            info.SortPropertyList.Add(New SortProperty("AccordionGroups", "tools.png", LocalizableOpen._0030))
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddSharedScripts(EnuSharedScript.jQueryUICore)
            MyBase.AddSharedScripts(EnuSharedScript.jQueryUIAccordion)
            MyBase.AddSharedScripts(EnuSharedScript.jQueryEasing)
            MyBase.AddExternalScripts(EnuScriptType.Css, "ElementsLibrary\Common\Css\WEAccordion.css", "WEFiles/Css/WEAccordion.css")
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEAccordion.js", "WEFiles/Client/WEAccordion.js")
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("WEAccordionHeader", LocalizableOpen._0147, LocalizableOpen._0148))
            configStylesZones.Add(New ConfigStylesZone("WEAccordionHeaderContent", LocalizableOpen._0314, LocalizableOpen._0321))
            configStylesZones.Add(New ConfigStylesZone("WEAccordionHeaderLeft", LocalizableOpen._0315, LocalizableOpen._0322))
            configStylesZones.Add(New ConfigStylesZone("WEAccordionHeaderRight", LocalizableOpen._0316, LocalizableOpen._0323))
            configStylesZones.Add(New ConfigStylesZone("WEAccordionHeaderActive", LocalizableOpen._0317, LocalizableOpen._0324))
            configStylesZones.Add(New ConfigStylesZone("WEAccordionHeaderContentActive", LocalizableOpen._0318, LocalizableOpen._0325))
            configStylesZones.Add(New ConfigStylesZone("WEAccordionHeaderLeftActive", LocalizableOpen._0319, LocalizableOpen._0326))
            configStylesZones.Add(New ConfigStylesZone("WEAccordionHeaderRightActive", LocalizableOpen._0320, LocalizableOpen._0327))

            configStylesZones.Add(New ConfigStylesZone("WEAccordionIcon", LocalizableOpen._0149, LocalizableOpen._0150))
            configStylesZones.Add(New ConfigStylesZone("WEAccordionTitle", LocalizableOpen._0151, LocalizableOpen._0152))
            configStylesZones.Add(New ConfigStylesZone("WEAccordionAltTitle", LocalizableOpen._0153, LocalizableOpen._0154))
            configStylesZones.Add(New ConfigStylesZone("WEAccordionContent", LocalizableOpen._0155, LocalizableOpen._0156))

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            Dim index As Integer = 0
            For Each group As WEAccordionGroup In Me.AccordionGroups

                'WEAccordionHeader
                writer.WriteBeginTag("div")
                writer.WriteAttribute("id", group.ID)
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionHeader"))
                writer.Write(HtmlTextWriter.TagRightChar)

                'WEAccordionHeaderLeft
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionHeaderLeft"))
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteEndTag("span")

                'WEAccordionHeaderContent
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionHeaderContent"))
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteBeginTag("a")
                writer.WriteAttribute("href", "#")
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteLine()

                If group.IconOff.IsEmpty() Or group.IconOn.IsEmpty() Then
                Else
                    'WEAccordionIcon
                    writer.WriteBeginTag("span")
                    writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionIcon"))

                    writer.Write(HtmlTextWriter.TagRightChar)

                    writer.WriteBeginTag("img")
                    If index.Equals(Me.OpenGroupIndex) Then
                        writer.WriteAttribute("src", MyBase.GetLink(group.IconOn))
                    Else
                        writer.WriteAttribute("src", MyBase.GetLink(group.IconOff))
                    End If
                    writer.WriteAttribute("style", "border:0px none")
                    writer.Write(HtmlTextWriter.SelfClosingTagEnd)

                    writer.WriteEndTag("span")
                    writer.WriteLine()
                End If

                'WEAccordionTitle
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionTitle"))
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.Write(group.Title.GetValue(Me.Page.Culture))
                writer.WriteEndTag("span")
                writer.WriteEndTag("a")
                writer.WriteLine()

                'WEAccordionAltTitle
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionAltTitle"))
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteBeginTag("a")
                writer.WriteAttribute("href", "#")
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.Write(group.AlternateTitle.GetValue(Me.Page.Culture))
                writer.WriteEndTag("a")
                writer.WriteEndTag("span")
                writer.WriteLine()

                writer.WriteEndTag("span") 'WEAccordionHeaderContent's end
                writer.WriteLine()

                'WEAccordionHeaderRight
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionHeaderRight"))
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteEndTag("span")
                writer.WriteLine()

                writer.WriteEndTag("div") 'WEAccordionHeader end

                'WEAccordionContent
                writer.WriteBeginTag("div")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionContent"))
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                writer.WriteBeginTag("div")
                writer.WriteAttribute("class", MyBase.GetTemplateClass(group.ID))
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                MyBase.RenderTemplate(writer, group.ID)

                writer.WriteLine()
                writer.WriteEndTag("div")

                writer.WriteLine()
                writer.WriteEndTag("div")

                index = index + 1
            Next

            MyBase.RenderEndTag(writer)
        End Sub

        ''' <summary>
        ''' Find a unique name for the new panel to accordion
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function NewTemplate() As String
            Dim templateName As String = Guid.NewGuid.ToString().Substring(0, 8)
            MyBase.Templates.SetTemplate(templateName, CssEnum.PositionMode.absolute)
            Return templateName
        End Function

        ''' <summary>
        ''' Check the panel name (must be unique)
        ''' </summary>
        ''' <param name="groups"></param>
        ''' <param name="templateName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function TemplateNameExiste(ByVal groups As List(Of WEAccordionGroup), ByVal templateName As String) As Boolean
            For Each group As WEAccordionGroup In groups
                If group.ID.Equals(templateName) Then Return True
            Next
            Return False
        End Function

        Private Sub UpdateTemplates(ByVal oldGroups As List(Of WEAccordionGroup), ByVal newGroups As List(Of WEAccordionGroup))
            For Each oldGroup As WEAccordionGroup In oldGroups
                If Not TemplateNameExiste(newGroups, oldGroup.ID) Then
                    MyBase.Templates.Templates.Remove(oldGroup.ID)
                End If
            Next
        End Sub

        #End Region 'Methods

    End Class

End Namespace

