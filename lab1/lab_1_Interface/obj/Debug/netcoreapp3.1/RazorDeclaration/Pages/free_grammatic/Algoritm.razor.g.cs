#pragma checksum "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\Pages\Free_grammatic\Algoritm.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e12a4bd9ecc941acac8dd73ff518a165f7a8751d"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace lab_1_Interface.Pages.Free_grammatic
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
#nullable restore
#line 1 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\Pages\Free_grammatic\Algoritm.razor"
using lab_1_Interface.Models;

#line default
#line hidden
#nullable disable
    public partial class Algoritm : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 119 "C:\Users\voen1\Desktop\-\[ТЯП] Теория языков программирования\lab1\lab1\lab_1_Interface\Pages\Free_grammatic\Algoritm.razor"
       
    Grammatic grammatic = new Grammatic();
    string input_vt_text, input_vn_text;
    string[] split_vt_text, split_vn_text;
    int num_regulars = 0;

    void save_regulars()
    {
        num_regulars++;
    }

    void inputVT()
    {
        if (input_vt_text?.Length > 0) {
            split_vt_text = input_vt_text.Split(",");
            grammatic.VT?.Clear();
            grammatic.VT = new List<string>();
            foreach (string list in split_vt_text) {
                grammatic.VT.Add(list);
            }
        }
    }

    void inputVN()
    {
        if (input_vn_text?.Length > 0) {
            split_vn_text = input_vn_text.Split(",");
            grammatic.VN?.Clear();
            grammatic.VN = new List<string>();
            foreach (string list in split_vn_text) {
                grammatic.VN.Add(list);
            }
        }
    }




#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
