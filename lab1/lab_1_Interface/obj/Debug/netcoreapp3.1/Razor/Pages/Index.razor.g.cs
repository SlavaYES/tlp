#pragma checksum "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6cae6e0f85d06ccefff7de81b85fb87fcfa3cb25"
// <auto-generated/>
#pragma warning disable 1591
namespace lab_1_Interface.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\_Imports.razor"
using lab_1_Interface;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\_Imports.razor"
using lab_1_Interface.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 5 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\Pages\Index.razor"
 
    protected override async Task OnInitializedAsync()
    {
        UriHelper.NavigateTo(UriHelper.BaseUri + "lab1", true);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager UriHelper { get; set; }
    }
}
#pragma warning restore 1591
