

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
1.3.8 -- 2/10/2012 RWC
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
* Added Toolbar containing Download Add / Remove All / Expand All -- Notice also the new simplified names (tool tips show more detail)
* Download dialog -- Download file count now includes the image file count.
* Download dialog -- Download total size now includes the image file(s) size.
* Download dialog -- Include tip: If you cancel the download. Restarting will resume from where you left off.
* Download dialog -- If over 10,000 files display warning (in background).

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
1.3.7 -- 25/9/2012 RWC
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
* MSHC Migrate -- Remove artificial node PackageThisRoot.htm (ID=PackThisRootID)

Microsoft have rules that stop nodes appearing if the meta tag Microsoft.Help.TopicVersion
does not match the parent node. To make matters worse VS 11 and VS 10 have slightly different
rules. Thus the best solution is to remove the artificial node and give all topics we package a TopicVersion=999. 

* MSHC Migrate -- File browser for output filename now goes to last path used.
* MSHC Migrate -- Warning displayed if using the Vendor Name = "Microsoft" since this forces the requirement of signing during installation. 
* Fix: The View Online page now correctly shows the selected Library (Msdn or Technet).
* Added Topics & Online tab so user can click and preview online topics.
* Open output folder in Explorer.exe once created.
* Allow custom .msha filename. With a warning that HV 1.0 requires the exact name HelpContentSetup.msha
* Added Expand command in Tree menu to expand all sup nodes (no download)
* Make the work directory <tempDir>\PackageThis\<dateTime>
* Make the cache directory <tempDir>\PackageThis\cache -- We are attempting to cache downloads for next time
