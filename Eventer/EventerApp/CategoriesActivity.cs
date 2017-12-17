using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using RestApiCallLibrary;
using System.Runtime.Remoting.Contexts;
using RestApiCallLibrary.Models;

namespace EventerApp
{
    [Activity(Label = "CategoriesActivity")]
    public class CategoriesActivity : ListActivity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            try
            {
                RestApiCall api = new RestApiCall(Resources.GetString(Resource.String.connectionString));
                List<Category> categories = api.GetCategoriesAsync();
                List<string> categoryNames = categories.Select(x => x.Name).ToList();
                ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, categoryNames);
                // Create your application here
            }
            catch (Exception ex)
            {

            }  
        }
    }
}