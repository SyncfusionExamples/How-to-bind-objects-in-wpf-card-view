# How to Bind Objects in WPF CardView

CardView is a flexible and visually appealing layout control that presents data in a card‑based format, making it ideal for displaying structured information in a clean and organized way. It is especially useful for applications that require modern UI layouts and responsive data presentation. 

This sample demonstrates how to **bind a collection of objects to the Syncfusion WPF CardView** control and display each object as a card using **data templates**.  
It also shows how to apply **validation** using `IDataErrorInfo` and data annotation attributes.

---

## Overview

The **Syncfusion WPF CardView** control displays data items in a card‑based layout.  Each card represents one object from a bound collection.

In this sample:
- A `ViewModel` exposes an `ObservableCollection<Contact>`
- Each `Contact` object is displayed as a card
- Card content and header are customized using templates
- Validation is implemented using `IDataErrorInfo`

---

## Why Use CardView?
Binding objects to CardView allows developers to:
- Display structured data such as customer profiles, product details, or employee records.
- Create visually rich layouts using DataTemplates.
- Improve UI clarity and user experience for data-driven applications.

---

## What This Sample Demonstrates

- Binding a collection of objects to `CardView`
- Using `ItemsSource` for object binding
- Customizing card content with `ItemTemplate`
- Customizing card headers with `HeaderTemplate`
- Implementing validation using `IDataErrorInfo`
- Using data annotations such as `Required` and `Range`

---

## Data Model and Validation

### Contact Class

```csharp
public class Contact : IDataErrorInfo
{
    [Required]
    public string Name { get; set; }

    [Range(1, 100)]
    public int Age { get; set; }

    #region IDataErrorInfo Members

    public string Error
    {
        get { return this[string.Empty]; }
    }

    public string this[string columnName]
    {
        get
        {
            string result = string.Empty;

            if (columnName == "Name")
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    result = "Name is mandatory";
                }
            }

            if (columnName == "Age")
            {
                if (this.Age < 1 || this.Age > 100)
                {
                    result = "Invalid Age";
                }
            }

            return result;
        }
    }

    #endregion
}
```

### ViewModel Implementation
The ViewModel exposes a collection of Contact objects and populates it with sample data.

```csharp
public class ViewModel
{
    public ObservableCollection<Contact> Contacts { get; set; }

    public ViewModel()
    {
        Contacts = new ObservableCollection<Contact>();
        PopulateData();
    }

    private void PopulateData()
    {
        Contacts.Add(new Contact() { Name = "John", Age = 26 });
        Contacts.Add(new Contact() { Name = "Mark", Age = 25 });
        Contacts.Add(new Contact() { Name = "Steven", Age = 26 });
    }
}
```
---

## XAML Binding and Templates
### Setting the DataContext

```XAML
<Window.DataContext>
    <local:ViewModel />
</Window.DataContext>
```

### CardView Binding with Templates

```XAML
<Grid>
    <syncfusion:CardView ItemsSource="{Binding Contacts}">

        <syncfusion:CardView.ItemTemplate>
            <DataTemplate>
                <ListBox>
                    <ListBoxItem>
                        <StackPanel Orientation="Horizontal">
                            <TextBlock Text="Name:" />
                            <TextBlock Text="{Binding Name}" Margin="5,0,0,0" />
                        </StackPanel>
                    </ListBoxItem>

                    <ListBoxItem>
                        <StackPanel Orientation="Horizontal">
                            <TextBlock Text="Age    :" />
                            <TextBlock Text="{Binding Age}" Margin="5,0,0,0" />
                        </StackPanel>
                    </ListBoxItem>
                </ListBox>
            </DataTemplate>
        </syncfusion:CardView.ItemTemplate>

        <syncfusion:CardView.HeaderTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Name}" />
            </DataTemplate>
        </syncfusion:CardView.HeaderTemplate>

    </syncfusion:CardView>
</Grid>
```
---
## Explanation
- ItemsSource binds the Contacts collection
- ItemTemplate defines how each card’s content is displayed
- HeaderTemplate displays the contact name as the card header

This sample helps developers quickly understand how to integrate CardView into WPF applications and leverage its powerful data‑binding capabilities.
