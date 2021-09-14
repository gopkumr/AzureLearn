#pragma checksum "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8607cface68986623cb41ffc35ec2e51a965a2b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CosmosDB), @"mvc.1.0.view", @"/Views/Home/CosmosDB.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Learn\azure\aspnetcore\TestWebApp\Views\_ViewImports.cshtml"
using TestWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Learn\azure\aspnetcore\TestWebApp\Views\_ViewImports.cshtml"
using TestWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8607cface68986623cb41ffc35ec2e51a965a2b6", @"/Views/Home/CosmosDB.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adcf018d0d57c86b8130e53afa8bfc7d57484832", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_CosmosDB : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CustomerOrder>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
  
    if (Model.Customer == null)
    {
        Model.Customer = new Customer();
    }

    if (Model.Order == null)
    {
        Model.Order = new Order();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 15 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 21 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
Write(Html.LabelFor(q => q.Customer.Name));

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
                                        ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
Write(Html.TextBoxFor(q => q.Customer.Name));

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
                                          ;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 24 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
Write(Html.LabelFor(q => q.Customer.City));

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
                                        ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
Write(Html.TextBoxFor(q => q.Customer.City));

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
                                          ;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <h2>Order</h2>\r\n");
#nullable restore
#line 28 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
Write(Html.LabelFor(q => q.Order.Item));

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
                                     ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
Write(Html.TextBoxFor(q => q.Order.Item));

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
                                       ;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 31 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
Write(Html.LabelFor(q => q.Order.Quantity));

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
                                         ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
Write(Html.TextBoxFor(q => q.Order.Quantity));

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
                                           ;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
            WriteLiteral("    <input type=\"submit\" value=\"Submit Customer Order\" />\r\n    <label>");
#nullable restore
#line 36 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
      Write(Model.ResponseMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n");
#nullable restore
#line 37 "D:\Learn\azure\aspnetcore\TestWebApp\Views\Home\CosmosDB.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CustomerOrder> Html { get; private set; }
    }
}
#pragma warning restore 1591
