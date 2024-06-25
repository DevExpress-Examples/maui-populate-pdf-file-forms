<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/671980886/23.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1181193)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Populate E-Forms in a PDF File

> NOTE
>
> This example requires the [DevExpress Office File API (Basic)](https://www.devexpress.com/buy). The DevExpress Office File API (Basic Edition) is included in the following DevExpress Subscriptions: Universal, DXperience, WinForms, WPF, and 

This example implements a view that opens a PDF File, obtains form fields, and allows you to populate them. The sample application supports a limited set of PDF form fields. You can extend the capabilities of this sample (and support additional PDF form fields) as requirements dictate. 

<img src="https://github.com/DevExpress-Examples/maui-populate-pdf-file-forms/assets/12169834/9b4feece-ddd1-452a-ab9e-71402d6657f3" width="30%"/>

**Related Controls and Their Properties**: 

* [OfficeFileAPI](https://docs.devexpress.com/MAUI/404434): [PdfDocumentProcessor](https://docs.devexpress.com/MAUI/DevExpress.Pdf.PdfDocumentProcessor), [PdfFormFieldFacade](https://docs.devexpress.com/MAUI/DevExpress.Pdf.PdfFormFieldFacade)
* [ToolbarItems](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.toolbaritem)
* [DataFormView](https://docs.devexpress.com/MAUI/403640): [DataObject](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView.DataObject), [IsAutoGenerationEnabled](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView.IsAutoGenerationEnabled), [ValidateProperty](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView.ValidateProperty)

## Implementation Details

* Call the [PdfDocumentProcessor.LoadDocument](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.LoadDocument.overloads) method to load a PDF file. If you open the PDF file included with this project, copy the file to the **AppData** folder first.
* Call the [PdfAcroFormFacade.GetFields](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfAcroFormFacade.GetFields) method to obtain form fields from the PDF file.

    
    ```xml
    DocumentProcessor.DocumentFacade.AcroForm.GetFields();
    ```
* You can determine field type, value, and settings. To change a field value, assign the new value to the [PdfTextFormFieldFacade.Value](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfTextFormFieldFacade.Value) property.	
    
    ```xml
    ((PdfTextFormFieldFacade)field).Value = "newValue";
    ```
* The *DataFormPropertySourceBehavior.PropertiesSource* property is bound to this collection and populates the [DataFormView](https://docs.devexpress.com/MAUI/403640) control with editors. The _DataFormPropertySourceBehavior.ItemTemplate_ property defines the template used to display DataFormView editors.
  
    ```xml
    <dxdf:DataFormView>
        <dxdf:DataFormView.Behaviors>
            <local:DataFormPropertySourceBehavior PropertiesSource="{Binding Properties}" ItemTemplate="{StaticResource formItemTemplateSelector}"/>
        </dxdf:DataFormView.Behaviors>
    </dxdf:DataFormView>
    ```
* This project creates an edit form using the [DataFormView](https://docs.devexpress.com/MAUI/403640) control bound to this _editedObject_ dictionary.
* The [ValidateProperty](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView.ValidateProperty) event validates form fields.
    
    ```
    private void dataform_ValidateProperty(object sender, DataFormPropertyValidationEventArgs e) {
        DataFormItem dataFormItem = ((DataFormView)sender).Items.FirstOrDefault(item => item.FieldName == e.PropertyName);
        if (dataFormItem != null && ((EditedItemModel)dataFormItem.BindingContext).IsRequired && (e.NewValue == null || (e.NewValue is string strValue && string.IsNullOrEmpty(strValue)))) {
            e.HasError = true;
        }
    }
    ```

* DataFormView editor type depends on the corresponding PDF field type:
  
  | PDF field type | DataFormView editor |
  |-|-|
  | Text | [DataFormTextItem](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormTextItem) |
  | Date | [DataFormDateItem](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormDateItem) |
  | Masked Text | [DataFormMaskedItem](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormMaskedItem) |
  | ComboBox | [DataFormComboBoxItem](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormComboBoxItem) |
  | RadioGroup| [DataFormComboBoxItem](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormComboBoxItem) |

* If the [DataFormComboBoxItem](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormComboBoxItem) contains a limited number of available items, it displays items within a popup. Otherwise, the [DataFormComboBoxItem.PickerShowMode](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormComboBoxItem.PickerShowMode) property is set to [BottomSheet](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.DropDownShowMode) and  displays the item list in the DevExpress .NET MAUI  [BottomSheet](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.BottomSheet) control. 

* The [PdfDocumentProcessor.SaveDocument](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.SaveDocument.overloads) method saves changes.
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=maui-populate-pdf-file-forms&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=maui-populate-pdf-file-forms&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
