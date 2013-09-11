Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.DB.DBElem

Namespace Elements.Form

    ''' <summary>
    ''' Form button 
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WEButton
        Inherits WEDynamic

#Region "Properties"
        ''' <summary>
        ''' button text value
        ''' </summary>
        ''' <remarks></remarks>
        Private _Text As DataType.LocalizableString

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N007"), _
        Ressource.localizable.LocalizableDescAtt("_D074"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString))> _
        Public Property Text() As DataType.LocalizableString
            Get
                If _Text Is Nothing Then _Text = New DataType.LocalizableString(My.Resources.text.LocalizablePropertyDefaultValue._0010)
                Return _Text
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _Text = value
            End Set
        End Property
#End Region

#Region "Builder required function "


        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEButton", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Width
        End Sub


        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0106
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WEButton
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0107
            Return info

        End Function


        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Button", My.Resources.text.LocalizableOpen._0125, My.Resources.text.LocalizableOpen._0124))

            MyBase.OnOpen(configStylesZones)
        End Sub

#End Region


#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            'dynamic code replacing old static code plus some dynamic features:
            DTWriteBeginTag("button", writer) ' , My.Resources.ResourceManager.GetString("_D007") 

            DTWriteClassesStatic(MyBase.GetStyleZoneClass("Button"))
            DTWriteAttrStatic("type", "button")
            DTWriteAttrStatic("name", ID)
            If IsDynamic Then
                ' "declare" empty html modifier assigned to style attribute, so that it can be edited in OE
                DTWriteAttrDynamic("style")
                '    DTWriteAttrDynamic("title")
                DTWriteAttrDynamic("data-oe-target-url", , , , True) ' optional alternative target page to send form to, and/or url parameters; True = generates no code if user didn't set corresponding HTML modifier
            End If

            DTTagEndDeclaration() ' end tag declaration <button....> - replaces writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            ' write text
            If IsDynamic Then
                DTWriteInnerHtmlDynamic(Nothing, Nothing, Text.GetValue(MyBase.Page.Culture))
                ' html modifier with default value = Me.Text and format editable in OE
            Else ' old static code
                DTWriteInnerHTMLStatic(Text.GetValue(MyBase.Page.Culture))
            End If

            DTWriteEndTag("button")

            MyBase.RenderEndTag(writer)

        End Sub



#End Region

        ' Add parent hidden elements using this element, ex. SendForm using this Form Button
        Public Overrides Sub AddElementsUsingThisElement(ByVal allPageElements As List(Of ElementBase), ByVal accList As List(Of ElementBase))
            If allPageElements Is Nothing OrElse accList Is Nothing Then Exit Sub
            For Each el As ElementBase In allPageElements
                If TypeOf el Is WESendForm Then
                    Dim sendForm As WESendForm = el
                    If sendForm.Config Is Nothing OrElse sendForm.Config.FormLinks Is Nothing Then Continue For
                    If sendForm.Config.FormLinks.ButtonSubmitID = Me.ID Or sendForm.Config.FormLinks.ButtonCancelID = Me.ID Then
                        accList.Add(el)
                    End If
                End If
                If TypeOf el Is WESendMail Then
                    Dim sendForm As WESendMail = el
                    If sendForm.FormLinks Is Nothing Then Continue For
                    If sendForm.FormLinks.ButtonSubmitID = Me.ID Or sendForm.FormLinks.ButtonCancelID = Me.ID Then
                        accList.Add(el)
                    End If
                End If
            Next
        End Sub


#Region "DD Translation of LocalizableStrings"

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
                                        ByVal accListLS As Dictionary(Of String, DataType.LocalizableString), _
                                        ByVal accListInfo As Dictionary(Of String, String), _
                                        Optional ByVal onlyNonEmpty As Boolean = True) As Boolean

            Dim r As Boolean = False
            r = r Or AddLSForTranslationSystem(_Text, "Text", "WEForm", "Button", accListLS, accListInfo, onlyNonEmpty)
            Return r
        End Function

#End Region

    End Class

End Namespace



