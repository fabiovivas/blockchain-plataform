#pragma checksum "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\Miner.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d87c33bce1417c4d822f301e665a62595eb7597"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Miner), @"mvc.1.0.view", @"/Views/Home/Miner.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Miner.cshtml", typeof(AspNetCore.Views_Home_Miner))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d87c33bce1417c4d822f301e665a62595eb7597", @"/Views/Home/Miner.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15e9fde603f251addea7f540217a2929b65e3fb3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Miner : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Blockchain.Core.Models.Transaction>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\Miner.cshtml"
  
    ViewData["Title"] = "Miner";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(139, 28, true);
            WriteLiteral("\r\n\r\n<nav class=\"navbar\">\r\n\r\n");
            EndContext();
#line 11 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\Miner.cshtml"
     using (Html.BeginForm("MinerTransactions", "Home", FormMethod.Post, new { @class = "form-inline" }))
    {

#line default
#line hidden
            BeginContext(281, 120, true);
            WriteLiteral("        <button id=\"btnReturnBlockchainJson\" type=\"submit\" style=\"\" class=\"btn btn-sm btn-primary\">Miner Pool</button>\r\n");
            EndContext();
#line 14 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\Miner.cshtml"
    }

#line default
#line hidden
            BeginContext(408, 306, true);
            WriteLiteral(@"
</nav>
<br />


<div class=""text-center"">
    <table class=""table table-bordered"">
        <thead>
            <tr>
                <th>Index</th>
                <th>Inputs</th>
                <th>Outputs</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 31 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\Miner.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(771, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(832, 9, false);
#line 35 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\Miner.cshtml"
               Write(item.TxId);

#line default
#line hidden
            EndContext();
            BeginContext(841, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(909, 22, false);
#line 38 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\Miner.cshtml"
               Write(item.InputList.Count());

#line default
#line hidden
            EndContext();
            BeginContext(931, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(999, 23, false);
#line 41 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\Miner.cshtml"
               Write(item.OutputList.Count());

#line default
#line hidden
            EndContext();
            BeginContext(1022, 89, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <button id=\"btnRemove\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1111, "\"", 1170, 3);
            WriteAttributeValue("", 1121, "Blockchain.Wallet.RemoveTransaction(\'", 1121, 37, true);
#line 44 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\Miner.cshtml"
WriteAttributeValue("", 1158, item.TxId, 1158, 10, false);

#line default
#line hidden
            WriteAttributeValue("", 1168, "\')", 1168, 2, true);
            EndWriteAttribute();
            BeginContext(1171, 91, true);
            WriteLiteral(" class=\"btn btn-sm btn-primary\">Remove</button>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 47 "C:\proj\FIAP\Blockchain-Plataform\Blockchain\Blockchain.Web\Views\Home\Miner.cshtml"
            }

#line default
#line hidden
            BeginContext(1277, 670, true);
            WriteLiteral(@"        </tbody>
    </table>
</div>

<div class=""modal fade"" tabindex=""-1"" role=""dialog"" aria-labelledby=""mySmallModalLabel"" aria-hidden=""true"" id=""mi-modal"">
    <div class=""modal-dialog modal-sm"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""myModalLabel"">Confirm deletion?</h4>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-default"" id=""modal-btn-no"">No</button>
                <button type=""button"" class=""btn btn-primary"" id=""modal-btn-si"">Yes</button>
            </div>
        </div>
    </div>
</div>

");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Blockchain.Core.Models.Transaction>> Html { get; private set; }
    }
}
#pragma warning restore 1591
