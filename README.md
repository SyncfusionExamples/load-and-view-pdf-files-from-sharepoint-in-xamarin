# Load and View PDF files from SharePoint in Xamarin

This repository contains the example which demonstrates how to access PDF files from the SharePoint and load them using Syncfusion&reg; Xamarin.Forms PDF Viewer. The sample focuses on accessing a PDF file from SharePoint, loading it as a stream, and displaying it within a mobile application. It is intended to show the core workflow required to integrate SharePoint-hosted PDF documents into a Xamarin.Forms app.

### What This Repository Demonstrates

Accessing a PDF document stored in SharePoint
Retrieving the PDF content as a stream
Displaying the PDF using Syncfusion Xamarin.Forms PDF Viewer
Loading PDF content directly from memory without saving it locally
Viewing SharePoint PDFs on Android and iOS using shared Xamarin code

This repository is designed as a reference example and keeps the implementation limited to the essential functionality required for viewing PDFs.

### Scope of the Sample
The sample demonstrates a single, focused scenario:

Viewing a predefined PDF file stored in SharePoint inside a Xamarin.Forms application

To keep the example clear and minimal, the following are intentionally not included:

File or library browsing
Upload or modification of documents
Offline storage or caching
Advanced PDF features such as annotations
Full authentication flows for all SharePoint environments


### How the Sample Works

The application requests a PDF file from SharePoint.
The PDF is downloaded as a stream.
The stream is passed directly to the Syncfusion PDF Viewer.
The PDF is rendered inside the application interface.

## Conclusion
This repository demonstrates a minimal and focused approach to loading and viewing PDF files from SharePoint in a Xamarin.Forms application using Syncfusion Xamarin.Forms PDF Viewer. It shows how a SharePoint-hosted PDF can be retrieved as a stream and rendered directly in the app, making it a useful reference for integrating SharePoint document viewing into mobile solutions.
