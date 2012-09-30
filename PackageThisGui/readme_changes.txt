1.3.7 -- 25/9/2012 RWC
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

* MSHC Migrate -- Remove artificial node PackageThisRoot.htm (ID=PackThisRootID)

Microsoft have rules that stop nodes appearing at TOC level 2 if the meta tag Microsoft.Help.TopicVersion
does not match the parent node at TOC Level 1. To make matters worse VS 11 and VS 10 have slightly different
rules. So in VS 11 I can fix nodes that don't appear by removing the TopicVersion tag from PackageThisRoot
but this can stop nodes from appearing in VS 10.

Thus the best solution is to remove the artificial node. Of course H3Viewer is much better at showing all nodes
but not everyone uses that and at this time that viewer does not support VS 11.

Solution is to remove the articial node.
If possible it would be good to modify the title of the package root so we can find it once integrated into VS help.

--
         
* MSHC Migrate -- File browser for output filename now goes to last path used.
* MSHC Migrate -- Warning displayed if using the Vendor Name = "Microsoft" since this forces the requirement of signing during installation. 
* Fix: The View Online page now correctly shows the selected Library (Msdn or Technet).
* Added Topics & Online tab so user can click and preview online topics.
* Open output folder in Explorer.exe once created.
* Allow custom .msha filename. With a warning that HV 1.0 requires the exact name HelpContentSetup.msha
* Added Expand command in Tree menu to expand all sup nodes (no download)
* Make the work directory <tempDir>\PackageThis\<dateTime>
* Make the cache directory <tempDir>\PackageThis\cache -- We are attempting to cache downloads for next time
