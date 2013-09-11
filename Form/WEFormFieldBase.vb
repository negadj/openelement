Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel

Namespace Elements.Form

    ''' <summary>Base class for form elements (V2) having InputName property</summary>
    <Serializable()> _
    Public MustInherit Class WEFormFieldBase
        Inherits openElement.DB.DBElem.WEDynamic

        Private _InputName As String

        ''' <summary>
        ''' input's name at the html file
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Expert), _
        Ressource.localizable.LocalizableNameAtt("_N208"), _
        Ressource.localizable.LocalizableDescAtt("_D207"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        MergableProperty(False)> _
        Public Property InputName() As String
            Get
                If String.IsNullOrEmpty(_InputName) Then
                    _InputName = Me.ID
                End If
                Return _InputName
            End Get
            Set(ByVal value As String)
                _InputName = value
            End Set
        End Property

#Region "Builder required function "

        Public Sub New(ByVal uniqueName As String, ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, uniqueName, page, parentID, templateName)
        End Sub

        Public Sub New(ByVal elementType As EnuElementType, ByVal uniqueName As String, ByRef page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(elementType, uniqueName, page, parentID, templateName)
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            Return info

        End Function
 
        Protected Overrides Sub OnOpen(ByVal configStylesZones As List(Of StylesManager.ConfigStylesZone), Optional ByVal deleteOldZones As Boolean = True)

            If configStylesZones Is Nothing Then MyBase.OnOpen() Else MyBase.OnOpen(configStylesZones, deleteOldZones)
        End Sub

        ''' <summary>When ID changes, update default name=ID for Form Field elements</summary>
        ''' <param name="oldID">Id before update</param>
        Protected Overrides Sub OnIDUpdated(ByVal oldID As String)
            If String.IsNullOrEmpty(oldID) Then Exit Sub

            If Page IsNot Nothing AndAlso Page.AddingElementsDuringUnpack Then
                ' Unpacking mode - when putting Pack's elements onto the page, keep Names when they are changed manually!

                ' if name is stored and = old ID, update name:
                If Not String.IsNullOrEmpty(_InputName) Then
                    If oldID = _InputName Then
                        _InputName = ID
                    End If
                End If
            Else
                ' Other scenarios - copy-paste, duplicate etc.

                InputName = ID
            End If
        End Sub

#End Region


#Region "DD Translation of LocalizableStrings"

        ' Called by descendants to add _Text field as localizable string to translate
        Protected Function AddFrmFieldLSForTranslationSystem(ByVal ls As LocalizableString, ByVal lsName As String, ByVal elementType As String, _
                                        ByVal accListLS As Dictionary(Of String, DataType.LocalizableString), _
                                        ByVal accListInfo As Dictionary(Of String, String), _
                                        Optional ByVal onlyNonEmpty As Boolean = True) As Boolean
            Return AddLSForTranslationSystem(ls, lsName, "WEForm", elementType, accListLS, accListInfo, onlyNonEmpty)
        End Function

#End Region


    End Class

End Namespace