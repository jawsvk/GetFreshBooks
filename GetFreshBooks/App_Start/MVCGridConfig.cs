[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GetFreshBooks.MVCGridConfig), "RegisterGrids")]

namespace GetFreshBooks
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;
    using MVCGrid.Models;
    using MVCGrid.Web;
    using Models;
    public static class MVCGridConfig 
    {

        public static void RegisterGrids()
        {
            GridDefaults defaultSet1 = new GridDefaults()
            {
                Paging = true,
                ItemsPerPage = 20,
                Sorting = true,
                NoResultsMessage = "Sorry, no results were found"
            };


            MVCGridDefinitionTable.Add("Inventory", new MVCGridBuilder<Book>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    // Add your columns here
                    cols.Add("BookID").WithColumnName("Book_ID")
                        .WithHeaderText("Book ID Number")
                        .WithValueExpression(i => i.BookID.ToString()); // use the Value Expression to return the cell text for this column
                    cols.Add("Title").WithColumnName("Book_Title")
                        .WithHeaderText("Book Title")
                        .WithValueExpression((i => i.Title));
                    cols.Add("Author").WithColumnName("Book_Author")
                      .WithHeaderText("Author")
                      .WithValueExpression((i => i.Author));
                    cols.Add("ISBN").WithColumnName("Book_ISBN")
                     .WithHeaderText("ISBN")
                     .WithValueExpression((i => i.ISBN));
                    cols.Add("Stock").WithColumnName("Book_Stock").WithSorting(true)
                  .WithHeaderText("Stock Number")
                  .WithValueExpression((i => i.Stock.ToString()));
                    cols.Add("Price").WithColumnName("Book_Price")
                  .WithHeaderText("Price").WithValueExpression((i => i.Price.ToString("C2")));
                    cols.Add("Edit").WithHtmlEncoding(false)
                 .WithSorting(false)
                 .WithHeaderText(" ")
                 .WithValueExpression((p, c) => c.UrlHelper.Action("Detail", "Inventory", new { id = p.BookID }))
                 .WithValueTemplate("<a href='{Value}' class='btn btn-primary' role='button'>Edit</a>");
                    cols.Add("Delete").WithHtmlEncoding(false)
                        .WithSorting(false)
                        .WithHeaderText(" ")
                        .WithValueTemplate("<a href='{Value}' class='btn btn-danger' role='button'>Delete</a>");
                  

                })
                .WithRetrieveDataMethod((context) =>
                {
                    // Query your data here. Obey Ordering, paging and filtering parameters given in the context.QueryOptions.
                    // Use Entity Framework, a module from your IoC Container, or any other method.
                    // Return QueryResult object containing IEnumerable<YouModelItem>
                    var result = new QueryResult<Book>();
                    result.Items = new BookshopEntities().Books.ToList();
                    return result;
                    //return new QueryResult<Book>()
                    //{
                    //    Items = new List<Book>(),
                        
                    //    TotalRecords = 0 //if paging is enabled, return the total number of all pages

                    //};
                })
            );
            
        }
    }
}