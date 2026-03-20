/*
' Copyright (c) 2026 ClosedAI
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

//using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;
using System.Collections.Generic;

namespace HelloWorld.Dnn.Dnn.ClosedAI.HelloWorld.Components
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for Dnn.ClosedAI.HelloWorld
    /// 
    /// The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    /// DotNetNuke will poll this class to find out which Interfaces the class implements. 
    /// 
    /// The IPortable interface is used to import/export content from a DNN module
    /// 
    /// The ISearchable interface is used by DNN to index the content of a module
    /// 
    /// The IUpgradeable interface allows module developers to execute code during the upgrade 
    /// process for a module.
    /// 
    /// Below you will find stubbed out implementations of each, uncomment and populate with your own data
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController //: IPortable, ISearchable, IUpgradeable
    {


        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        //public string ExportModule(int ModuleID)
        //{
        //string strXML = "";

        //List<Dnn.ClosedAI.HelloWorldInfo> colDnn.ClosedAI.HelloWorlds = GetDnn.ClosedAI.HelloWorlds(ModuleID);
        //if (colDnn.ClosedAI.HelloWorlds.Count != 0)
        //{
        //    strXML += "<Dnn.ClosedAI.HelloWorlds>";

        //    foreach (Dnn.ClosedAI.HelloWorldInfo objDnn.ClosedAI.HelloWorld in colDnn.ClosedAI.HelloWorlds)
        //    {
        //        strXML += "<Dnn.ClosedAI.HelloWorld>";
        //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objDnn.ClosedAI.HelloWorld.Content) + "</content>";
        //        strXML += "</Dnn.ClosedAI.HelloWorld>";
        //    }
        //    strXML += "</Dnn.ClosedAI.HelloWorlds>";
        //}

        //return strXML;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        //public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        //{
        //XmlNode xmlDnn.ClosedAI.HelloWorlds = DotNetNuke.Common.Globals.GetContent(Content, "Dnn.ClosedAI.HelloWorlds");
        //foreach (XmlNode xmlDnn.ClosedAI.HelloWorld in xmlDnn.ClosedAI.HelloWorlds.SelectNodes("Dnn.ClosedAI.HelloWorld"))
        //{
        //    Dnn.ClosedAI.HelloWorldInfo objDnn.ClosedAI.HelloWorld = new Dnn.ClosedAI.HelloWorldInfo();
        //    objDnn.ClosedAI.HelloWorld.ModuleId = ModuleID;
        //    objDnn.ClosedAI.HelloWorld.Content = xmlDnn.ClosedAI.HelloWorld.SelectSingleNode("content").InnerText;
        //    objDnn.ClosedAI.HelloWorld.CreatedByUser = UserID;
        //    AddDnn.ClosedAI.HelloWorld(objDnn.ClosedAI.HelloWorld);
        //}

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        //{
        //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

        //List<Dnn.ClosedAI.HelloWorldInfo> colDnn.ClosedAI.HelloWorlds = GetDnn.ClosedAI.HelloWorlds(ModInfo.ModuleID);

        //foreach (Dnn.ClosedAI.HelloWorldInfo objDnn.ClosedAI.HelloWorld in colDnn.ClosedAI.HelloWorlds)
        //{
        //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objDnn.ClosedAI.HelloWorld.Content, objDnn.ClosedAI.HelloWorld.CreatedByUser, objDnn.ClosedAI.HelloWorld.CreatedDate, ModInfo.ModuleID, objDnn.ClosedAI.HelloWorld.ItemId.ToString(), objDnn.ClosedAI.HelloWorld.Content, "ItemId=" + objDnn.ClosedAI.HelloWorld.ItemId.ToString());
        //    SearchItemCollection.Add(SearchItem);
        //}

        //return SearchItemCollection;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        //public string UpgradeModule(string Version)
        //{
        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        #endregion

    }

}
