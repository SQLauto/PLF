using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Common
{
    public class UploadFileToSharePointSite
    {
        public static void PushFile()
        {
            String fileToUpload = @"C:\YourFile.txt";
            String sharePointSite = "http://yoursite.com/sites/Research/";
            String documentLibraryName = "Shared Documents";

            using (SPSite oSite = new SPSite(sharePointSite))
            {
                using (SPWeb oWeb = oSite.OpenWeb())
                {
                    if (!System.IO.File.Exists(fileToUpload))
                        throw new FileNotFoundException("File not found.", fileToUpload);

                    SPFolder myLibrary = oWeb.Folders[documentLibraryName];

                    // Prepare to upload
                    Boolean replaceExistingFiles = true;
                    String fileName = System.IO.Path.GetFileName(fileToUpload);
                    FileStream fileStream = System.IO.File.OpenRead(fileToUpload);

                    // Upload document
                    SPFile spfile = myLibrary.Files.Add(fileName, fileStream, replaceExistingFiles);

                    // Commit 
                    myLibrary.Update();
                }
            }
        }
        public static string PushToSite(string type, byte[] result, string schoolYear, string schoolCode, string schoolName, string schoolNameB)
        {
            string siteUrl = WebConfig.getValuebyKey("SLIPSchoolSiteUrl");
            string documentCategory = WebConfig.getValuebyKey("DocumentCategory");
            string documentCategoryB = WebConfig.getValuebyKey("DocumentCategoryBrief");
            string documentLibrary = WebConfig.getValuebyKey("DocumentLibrary");
            return PushProcessInsideProject(type, result, schoolYear, schoolCode, schoolName, schoolNameB, siteUrl, documentCategory, documentCategoryB, documentLibrary);
            // return PushProcessWebService(type, result, schoolYear, schoolCode, schoolName, schoolNameB, siteUrl, documentCategory, documentCategoryB, documentLibrary);
        }
        public static string PushProcessWebService(byte[] result, string schoolYear, string schoolCode, string schoolName, string schoolNameB, string siteUrl, string documentCategory, string documentCategoryB, string documentLibrary)
        {
            try
            {
                PublishDocumentToSPSite.PublishDocToSP uploadWS = new PublishDocumentToSPSite.PublishDocToSP();
                uploadWS.DocumentByCategoryToSite("SLIP", schoolYear, schoolCode, schoolName, schoolNameB, siteUrl, documentCategory, documentCategoryB, documentLibrary, result);
                return "Successfully";
            }
            catch (Exception ex)
            {
                string _ex = ex.Message;
                return "Failed"; }
        }
        public static string PushProcessInsideProject(string type, byte[] result, string schoolYear, string schoolCode, string schoolName, string schoolNameB, string siteUrl, string documentCategory, string documentCategoryB, string documentLibrary)
        {
            string spSiteUser = WebConfig.getValuebyKey("SPSiteUser");
            string spSiteUserPW = WebConfig.getValuebyKey("SPSiteUserPW");
            try
            {
                using (ClientContext ctx = new ClientContext(siteUrl))   ///("http://www.tcdsb.org/sites/CommonData")
                {
                    ctx.Credentials = new System.Net.NetworkCredential(spSiteUser, spSiteUserPW);

                    Web site = ctx.Web;
                    //get the document library folder
                    Folder folder = site.GetFolderByServerRelativeUrl(documentLibrary);
                    ctx.ExecuteQuery();
                    //load the file collection for the documents in the library
                    FileCollection fileCollection = folder.Files;
                    ctx.Load(fileCollection);
                    ctx.ExecuteQuery();
                    ctx.Load(site);
                    ctx.Load(site.Lists);
                    string term_value_school_year = GetTermValue(  ctx, "School Year", schoolYear);
                    if (term_value_school_year == string.Empty)
                    {
                        throw new Exception();
                    }
                    if (schoolCode == "" || schoolName == "" || schoolNameB == "")
                    {
                        throw new Exception();
                    }

                    string term_value_school = GetTermValue(  ctx, "School", schoolCode);
                    if (term_value_school == string.Empty)
                    {
                        throw new Exception();
                    }

                    FileCreationInformation fileCI = new FileCreationInformation();

                    fileCI.Content = result;
                    fileCI.Url = schoolNameB + schoolYear + documentCategoryB;
                    fileCI.Url = fileCI.Url.Replace(" ", "").Replace("-", "").Replace("_", "").Replace("/", "").Replace(".", "").Replace("&", "").Replace("'", "") + ".PDF";

                    fileCI.Overwrite = true;

                    //add this file to the file collection
                    Microsoft.SharePoint.Client.File newFile = fileCollection.Add(fileCI);

                    ctx.Load(newFile);
                    ctx.ExecuteQuery();

                    ListItem li = newFile.ListItemAllFields;
                    li["TcdsbEqaoType"] = documentCategory;
                    li["TcdsbSchool"] = term_value_school;
                    li["TcdsbSchoolYear"] = term_value_school_year;
                    li["Title"] = schoolName + " " + schoolYear + " " + documentCategory;

                    li.Update();
                    ctx.ExecuteQuery();

                }

                return "Successful";
            }
            catch (Exception ex)
            {
                string _ex = ex.Message;
                return "Failed"; }
        }

        public static string GetTermValue(  ClientContext context, string fieldName, string term)
        {
            try
            {
                string termID = "";
                string SP_fieldName = "";
                string SP_listTitleName = "";
                if (fieldName == "School Year")
                {
                    SP_fieldName = "Title";
                    SP_listTitleName = "SchoolYears";
                }
                if (fieldName == "School")
                {
                    SP_fieldName = "Code";
                    SP_listTitleName = "OuInformation";
                }

               //  int.TryParse(WebConfig.getValuebyKey("SPSiteMaxSchoolsList"), out int MaxList);
                int MaxList = 250;
                CamlQuery query = CamlQuery.CreateAllItemsQuery(MaxList);
                List yList = context.Web.Lists.GetByTitle(SP_listTitleName);
                ListItemCollection items = yList.GetItems(query);
                context.Load(items);
                context.ExecuteQuery();
                foreach (ListItem listItem in items)
                {
                    if (listItem[SP_fieldName].ToString() == term)
                    {
                        termID = listItem["TermGuid"].ToString();
                    }
                }

                if (termID != string.Empty)
                { 
                    termID = "-1" + ";#" + term + "|" + termID;
                }
                return termID;
            }
            catch (Exception ex)
            {
                string _ex = ex.Message;
                return "";
            }

        }

    }
}
