// Copyright (c) Microsoft Corporation.  All rights reserved.
//
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Services;
using PackageThis.com.microsoft.msdn.services;
using System.Xml;

namespace ContentServiceLibrary
{
        
        static public class rootContentItem
        {

            static public readonly List<string> libraries = 
                new List<string> ( new string[]{ "MSDN Library", "TechNet Library" });

            static private string[] contentIds = { "ms310241", "Bb126093" };
            static private string[] versions = { "MSDN.10", "TechNet.10" };

            static public int currentLibrary = 0;

            static public string contentId
            {
                get
                {
                    return contentIds[currentLibrary];
                }
            }

            static public string version
            {
                get
                {
                    return versions[currentLibrary];
                }
            }

            static public string name
            {
                get
                {
                    return libraries[currentLibrary];
                }
            }

            static public bool msdnSelected
            {
                get
                {
                    return contentIds[currentLibrary] == "ms310241";
                }
            }

            
        }


    public class ContentItem
    {
        public string xml;
        public string metadata;
        public string annotations;
        public string toc;
        public string contentId;
        public int numImages;
        public int sizeImages;
        public string links;
        public string application;

        public string contentIdentifier;
        //string aKeyword;
        string locale;
        string version;
        string collection;

        public List<Image> images = new List<Image>();

        // Because strings returned from the server are used as filenames for pictures and html files, 
        // validate against very restricted set of characters.
        // \w is equivalent to [a-zA-Z0-9_].
        static Regex validateAsFilename = new Regex(@"^[-\w.]+$");


        public ContentItem(string contentIdentifier, string locale, 
            string version, string collection, string application)
        {
            this.contentIdentifier = contentIdentifier;
            this.locale = locale;
            this.version = version;
            this.collection = collection;
            this.application = application;
        }

        public ContentItem(string contentIdentifier)
        {
            this.contentIdentifier = contentIdentifier;
        }

        // Iterator to return filenames in the format required by the xhtml.
        public IEnumerable ImageFilenames
        {
            get
            {
                for (int i = 0; i < images.Count; i++)
                {
                    if (images[i].data == null)
                        continue;

                    yield return GetImageFilename(images[i]);
                }
            }
        }


        //Echo these back out for convenience
        public String Locale { get { return this.locale; } }
        public String Product { get { return this.collection + "." + this.version; } }


        public void Load(bool loadImages)
        {
            Load(loadImages, true);
        }

        // Added the loadFailSafe optimization
        public void Load(bool loadImages, bool loadFailSafe)
        {

            getContentRequest request = new getContentRequest();

            request.contentIdentifier = contentIdentifier;
            request.locale = locale;
            request.version = collection + "." + version;

            List<requestedDocument> documents = new List<requestedDocument>();


            requestedDocument document = new requestedDocument();
            document.selector = "Mtps.Links";
            document.type = documentTypes.common;
            documents.Add(document);

            document = new requestedDocument();
            document.type = documentTypes.primary;
            document.selector = "Mtps.Toc";
            documents.Add(document);

            document = new requestedDocument();
            document.type = documentTypes.common;
            document.selector = "Mtps.Search";
            documents.Add(document);

            // Mtps.Annotations removed because it caused many bugs
            /*document = new requestedDocument();
            document.type = documentTypes.feature;
            document.selector = "Mtps.Annotations";
            documents.Add(document);*/

            if (loadFailSafe == true)
            {
                document = new requestedDocument();
                document.type = documentTypes.primary;
                document.selector = "Mtps.Failsafe";
                documents.Add(document);
            }

            request.requestedDocuments = documents.ToArray();

            ContentService proxy = new ContentService();
            proxy.appIdValue = new appId();
            proxy.appIdValue.value = application;

            getContentResponse response;

            try
            {
                response = proxy.GetContent(request);
            }
            catch
            {
                return;
            }

            if (validateAsFilename.Match(response.contentId).Success == true)
            {
                contentId = response.contentId;
            }
            else
            {
                throw (new BadContentIdException("ContentId contains illegal characters: [" + contentId + "]"));
            }
            

            numImages = response.imageDocuments.Length;
            

            foreach (common commonDoc in response.commonDocuments)
            {
                if (commonDoc.Any != null)
                {
                    switch (commonDoc.commonFormat.ToLower())
                    {
                        case "mtps.search":
                            metadata = commonDoc.Any[0].OuterXml;
                            break;

                        case "mtps.links":
                            links = commonDoc.Any[0].OuterXml;
                            break;

                    }
                }
            }

            foreach (primary primaryDoc in response.primaryDocuments)
            {
                if (primaryDoc.Any != null)
                {
                    switch (primaryDoc.primaryFormat.ToLower())
                    {
                        case "mtps.failsafe":
                            RemoveDuplicateSentences(primaryDoc.Any);
                            xml = primaryDoc.Any.OuterXml;
                            break;

                        case "mtps.toc":
                            toc = primaryDoc.Any.OuterXml;
                            break;
                    }
                }
            }


            /*foreach (feature featureDoc in response.featureDocuments)
            {
                if (featureDoc.Any != null)
                {
                    if (featureDoc.featureFormat.ToLower() == "mtps.annotations")
                    {
                        annotations = featureDoc.Any[0].OuterXml;
                    }
                }
            }*/

            // If we get no meta/search or wiki data, plug in NOP data because
            // we can't LoadXml an empty string nor pass null navigators to
            // the transform.
            if (string.IsNullOrEmpty(metadata) == true)
                metadata = "<se:search xmlns:se=\"urn:mtpg-com:mtps/2004/1/search\" />";
            //if (string.IsNullOrEmpty(annotations) == true)
                annotations = "<an:annotations xmlns:an=\"urn:mtpg-com:mtps/2007/1/annotations\" />";

            sizeImages = 0;
            if (loadImages == true)
            {
                requestedDocument[] imageDocs = new requestedDocument[response.imageDocuments.Length];

                // Now that we know their names, we run a request with each image.
                for (int i = 0; i < response.imageDocuments.Length; i++)
                {
                    imageDocs[i] = new requestedDocument();
                    imageDocs[i].type = documentTypes.image;
                    imageDocs[i].selector = response.imageDocuments[i].name + "." +
                        response.imageDocuments[i].imageFormat;
                }

                request.requestedDocuments = imageDocs;
                response = proxy.GetContent(request);

                foreach (image imageDoc in response.imageDocuments)
                {
                    string imageFilename = imageDoc.name + "." + imageDoc.imageFormat;
                    if (validateAsFilename.Match(imageFilename).Success == true)
                    {
                        images.Add(new Image(imageDoc.name, imageDoc.imageFormat, imageDoc.Value));
                        sizeImages = sizeImages + imageDoc.Value.Length;
                    }
                    else
                    {
                        throw (new BadImageNameExeception(
                            "Image filename contains illegal characters: [" + imageFilename + "]"));
                    }

                }
            }

        }

        private void RemoveDuplicateSentences(XmlElement node)
        {
            var dublicates = new List<XmlNode>();
            var handledTags = new List<string>();

            foreach (XmlNode sentenceNode in node.SelectNodes("//*[@class='tgtSentence']"))
            {
                XmlNode tagIdAttr = sentenceNode.Attributes.GetNamedItem("id");
                if (tagIdAttr == null)
                    continue;

                string tagId = tagIdAttr.Value;

                if (handledTags.Contains(tagId))
                {
                    dublicates.Add(sentenceNode);
                    continue;
                }

                handledTags.Add(tagId);
            }

            for (int i = dublicates.Count - 1; i >= 0; i--)
            {
                XmlNode nodeToRemove = dublicates[i];
                if (nodeToRemove.ParentNode != null)
                {
                    XmlNode parentNode = nodeToRemove.ParentNode;
                    parentNode.RemoveChild(nodeToRemove);
                }
            }
        }


        // Returns the navigation node that corresponds to this content. If
        // we give it a navigation node already, it'll return that node, so
        // no harm done.
        public string GetNavigationNode()
        {
            // Load the contentItem. If we get a Toc entry, then we know it is
            // a navigation node rather than a content node. The reason is that
            // getNavigationPaths only returns the root node if the target node is
            // a navigation node already. We could check to see if we get one path
            // consisting of one node, but the user could give a target node that is
            // the same as the root node. Perf isn't an issue because this should
            // only be called once with the rootNode.

            this.Load(false); // Don't load images in case we are a content node.
            
            if(toc != null)
                return contentId;

            navigationKey root = new navigationKey();
            root.contentId = rootContentItem.contentId;
            root.locale = locale;
            root.version = rootContentItem.version;

            navigationKey target = new navigationKey();
//            target.contentId = "AssetId:" + assetId;
            target.contentId = contentId;
            target.locale = locale;
            target.version = collection + "." + version;

            ContentService proxy = new ContentService();
            getNavigationPathsRequest request = new getNavigationPathsRequest();
            request.root = root;
            request.target = target;

            getNavigationPathsResponse response = proxy.GetNavigationPaths(request);

            // We need to deal with the case where the content appears in many
            // places in the TOC. For now, just use the first path.
            if (response.navigationPaths.Length == 0)
                return null;

            // This is the last node in the first path.
           return response.navigationPaths[0].navigationPathNodes[
                response.navigationPaths[0].navigationPathNodes.Length - 1].navigationNodeKey.contentId;
           
        }

        public void Write(string directory)
        {
            Write(directory, contentId + ".htm");
        }

        public void Write(string directory, string filename)
        {
            if (xml == null)
                return;

            //Save image files

            int i = -1;
            String[] imageFiles = new String[images.Count];

            foreach (Image image in images)
            {
                i++;
                if (image.data == null)
                    continue;

                imageFiles[i] = GetImageFilename(image);
                using (BinaryWriter bw = new BinaryWriter(File.Open(Path.Combine(directory, imageFiles[i]), FileMode.Create)))
                {
                    bw.Write(image.data, 0, image.data.Length);
                }

            }

            //Adjust Image Links in topic xml
            if (images.Count != 0)
                xml = FixImageLinks.XmlFixLinks(xml, imageFiles);

            //Save HTML file

            using (StreamWriter sw = new StreamWriter(Path.Combine(directory, filename)))
            {
                sw.Write(xml);
            }
        }

        private string GetImageFilename(Image image)
        {
            return contentId + "." + image.name + "(" + locale +
                 "," + collection + "." + version + ")." + image.imageFormat;
        }


    }



    public static class FixImageLinks
    {
        public static String XmlFixLinks(string xml, string[] imageFiles)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);
            XmlNodeList imgNodes = xmldoc.GetElementsByTagName("img");    //get all <img> nodes

            foreach (XmlNode node in imgNodes)
            {
                if (node == null || node.Name != "img" || node.Attributes.Count < 2)
                    continue;

                String srcValue = node.Attributes["src"].Value;
                String filename = FindFullFilename(srcValue, imageFiles);

                // Src= link already set correctly?

                if (String.IsNullOrEmpty(srcValue) == false && srcValue == filename)
                    continue;

                // Found a better match?

                if (filename.Length != 0)
                {
                    node.Attributes["src"].Value = srcValue;
                    continue;
                }

                // Need to look in the preceeding comment <!-- .. ImageName="bingo" .. -->

                XmlNode lastNode = node.PreviousSibling;
                if (lastNode != null && lastNode.NodeType == XmlNodeType.Comment)
                {
                    String imageName = ExtractImageNameFromComment(lastNode.Value);  // pass full comment //<!-- .. ImageName="bingo" .. -->
                    filename = FindFullFilename(imageName, imageFiles);
                    if (filename.Length != 0)
                    {
                        node.Attributes["src"].Value = filename;    //found a filename
                        continue;
                    }
                }

                // No match? Use first img in list -- Changes are it's the right one!

                //node.Attributes["src"].Value = imageFiles[0];
            }

            return xmldoc.OuterXml;
        }


        private static String FindFullFilename(String nameFragment, string[] imageFiles)
        {
            if (nameFragment.Length != 0)
                foreach (String iname in imageFiles)
                    if (iname != null && iname.IndexOf(nameFragment) >= 0)
                        return iname;
            return "";
        }

        private static String ExtractImageNameFromComment(String sComment)
        {
            const string attrName = "ImageName=\"";
            int p1 = sComment.IndexOf(attrName);
            if (p1 >= 0)
            {
                p1 = p1 + attrName.Length;      //first char after opening "
                int p2 = sComment.IndexOf('"', p1);    //closing "
                if (p2 > p1)
                    return sComment.Substring(p1, p2 - p1);
            }
            return "";
        }

    }

    public class BadContentIdException : ApplicationException
    {
        public BadContentIdException(string message) : base(message)
        {
        }

    }

    public class BadImageNameExeception : ApplicationException
    {
        public BadImageNameExeception(string message) : base(message)
        {
        }
    }
}
