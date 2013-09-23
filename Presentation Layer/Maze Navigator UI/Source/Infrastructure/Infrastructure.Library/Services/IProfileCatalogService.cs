//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by this guidance package as part of the solution template
//
// The IProfileCatalogService interface abstract the implementation to retrieve the 
// profile catalog from a given Url
// 
//  
//
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System;
namespace MazeNavigatorUI.Infrastructure.Library.Services
{
    public interface IProfileCatalogService
    {
        string GetProfileCatalog(string[] roles);
        string Url { get; set; }
    }
}
