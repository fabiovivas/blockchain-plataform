#pragma checksum "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\_CreateWallet.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "294205a9cdd6781f2adb8b9ee64945d6b33d0a68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__CreateWallet), @"mvc.1.0.view", @"/Views/Home/_CreateWallet.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_CreateWallet.cshtml", typeof(AspNetCore.Views_Home__CreateWallet))]
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
#line 1 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\_ViewImports.cshtml"
using Blockchain.Web;

#line default
#line hidden
#line 2 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\_ViewImports.cshtml"
using Blockchain.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"294205a9cdd6781f2adb8b9ee64945d6b33d0a68", @"/Views/Home/_CreateWallet.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15e9fde603f251addea7f540217a2929b65e3fb3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__CreateWallet : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WalletModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(20, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\_CreateWallet.cshtml"
 using (Html.BeginForm("CreateWallet", "Home", FormMethod.Post, new { id = "formWallet" }))
{

#line default
#line hidden
            BeginContext(118, 129, true);
            WriteLiteral("    <section class=\"container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"form-group col-lg-6\">\r\n                ");
            EndContext();
            BeginContext(248, 34, false);
#line 8 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\_CreateWallet.cshtml"
           Write(Html.LabelFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(282, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(301, 86, false);
#line 9 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\_CreateWallet.cshtml"
           Write(Html.TextBoxFor(model => model.Name, new { @class = "form-control", maxlength = 100 }));

#line default
#line hidden
            EndContext();
            BeginContext(387, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(406, 82, false);
#line 10 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\_CreateWallet.cshtml"
           Write(Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(488, 54, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </section>\r\n");
            EndContext();
#line 14 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\_CreateWallet.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WalletModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
