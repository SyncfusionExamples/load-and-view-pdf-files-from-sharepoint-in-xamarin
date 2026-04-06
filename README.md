# Load and View PDF files from SharePoint in Xamarin

This repository contains an example that demonstrates how to access PDF files from SharePoint and load them using the Syncfusion® Xamarin.Forms PDF Viewer. The sample focuses on retrieving a PDF file from SharePoint, loading it as a stream, and displaying it within a Xamarin.Forms application.

The purpose of this repository is to illustrate the core workflow required to integrate SharePoint-hosted PDF documents into a Xamarin.Forms project.

## Overview

This sample demonstrates a focused approach for viewing PDF documents stored in SharePoint. Instead of downloading and saving files locally, the PDF content is retrieved as a stream and rendered directly using the Xamarin PDF Viewer.

This approach minimizes storage dependencies while enabling secure access to SharePoint-hosted documents.

## Supported Platforms

This sample supports the following platforms:

- Android  
- iOS  
- UWP (Universal Windows Platform)

The PDF loading and viewing behavior remains consistent across all supported platforms using shared Xamarin.Forms logic.

## What This Repository Demonstrates

The sample highlights the following capabilities:

- Accessing a PDF document stored in SharePoint  
- Retrieving PDF content as a stream  
- Loading and displaying PDFs using Syncfusion Xamarin.Forms PDF Viewer  
- Rendering PDF content directly from memory without local file storage  

This repository is designed as a reference implementation and intentionally focuses only on essential functionality.

## Scope of the Sample

The sample demonstrates a single, focused scenario:

- Viewing a predefined PDF file stored in SharePoint within a Xamarin.Forms project  

To keep the example simple and easy to understand, the following features are not included:

- File or library browsing  
- Uploading or modifying documents  
- Offline storage or caching  
- Advanced PDF features such as annotations  
- Complete authentication flows for all SharePoint environments  

## How the Sample Works

The workflow followed in the sample is:

- A request is made to SharePoint for a PDF file  
- The PDF content is downloaded as a stream  
- The stream is passed directly to the Syncfusion PDF Viewer  
- The PDF document is rendered within the viewer interface  

## Conclusion

This repository demonstrates a minimal and effective approach to loading and viewing PDF files from SharePoint using the Syncfusion Xamarin.Forms PDF Viewer. It provides a clear reference for retrieving SharePoint-hosted PDFs as streams and rendering them directly within a Xamarin.Forms solution.

For more details, refer to the official Syncfusion [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-viewer/xamarin/overview) and [API reference](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfPdfViewer.XForms.html).
