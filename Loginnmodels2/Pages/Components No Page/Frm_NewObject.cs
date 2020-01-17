using System;
using System.Linq;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using System.Reflection;
using System.Collections.Generic;
using Blazored.Modal;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Loginnmodels2.Pages
{
    public class Frm_NewObject : ComponentBase
    {
        [Parameter] public object generic_object { get; set; }
        [CascadingParameter] ModalParameters Parameters { get; set; }
        private List<PropertyInfo> Propiedades;
        private Type generic_object_type;
        

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            //if (generic_object == null) 



            GetListOfProperties();
            int counter = 0;
            builder.OpenElement(++counter, "EditForm"); builder.AddAttribute(++counter, "Model", generic_object); builder.AddAttribute(++counter, "OnValidSubmit", new Action(async () => await SubmitForm()) );
            builder.OpenElement(++counter, "table");
            builder.OpenElement(++counter, "tbody");

            foreach (var item in Propiedades)
            {
                builder.OpenElement(++counter, "tr");

                builder.OpenElement(++counter, "td");
                builder.AddContent(++counter, item.Name);
                builder.CloseElement();

                builder.OpenElement(++counter,  "td");
                //builder.AddContent(++counter, item.PropertyType.ToString());
                builder.OpenElement(++counter,  "input");
                
                switch (item.PropertyType.ToString())
                {
                    case "System.String":   builder.AddAttribute(++counter, "type", "text");  builder.AddAttribute(++counter, "bind-Value", generic_object.GetType().GetProperty(item.PropertyType.ToString()));break;
                    case "System.Int32":    builder.AddAttribute(++counter, "type", "number"); builder.AddAttribute(++counter, "bind-Value", generic_object.GetType().GetProperty(item.PropertyType.ToString())); break;
                    case "System.Int64":    builder.AddAttribute(++counter, "type", "number"); builder.AddAttribute(++counter, "bind-Value", generic_object.GetType().GetProperty(item.PropertyType.ToString())); break;
                    case "System.DateTime": builder.AddAttribute(++counter, "type", "date"); builder.AddAttribute(++counter, "bind-Value", generic_object.GetType().GetProperty(item.PropertyType.ToString())); break;
                    case "System.Boolean":  builder.AddAttribute(++counter, "type", "checkbox"); builder.AddAttribute(++counter, "bind-Value", generic_object.GetType().GetProperty(item.PropertyType.ToString())); break;
                }
                
                builder.CloseElement();

                builder.CloseElement();
                builder.CloseElement();

            }

            builder.CloseElement();
            builder.CloseElement();
            builder.CloseElement();
            builder.OpenElement(++counter, "button");
            builder.AddAttribute(++counter, "type", "submit");
            //builder.AddAttribute(++counter, "onclick", new Action(() => onclick()));
            builder.AddContent(++counter, "Click");
            builder.CloseElement();
            builder.AddContent(++counter, "<span> id = 'resultJson'> </span> ");

            
        }
        
        private void GetListOfProperties()
        {
            Propiedades = new List<PropertyInfo>();
            if (generic_object == null)
            {

                var a = Parameters.Get<object>("Generic").GetType().GetProperties();

                foreach (var b in a)
                {
                    Propiedades.Add(b);
                }
                generic_object_type = Parameters.Get<object>("Generic").GetType();
            }
            else
            {
                generic_object_type = generic_object.GetType();
            }
            
        }

        

        public void onclick(System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Hello");
           

        }

        private async Task SubmitForm()
        {

        }
    }


}
