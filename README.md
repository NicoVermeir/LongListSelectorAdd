LongListSelectorAdd
===================

This repo is added to illustrate a problem with the native wp8 SDK LongListSelector control

When used in Grouped mode, it will always position itself to the last added item! Meaning when you have a sorted list, it will be at the bottom...
This is a weird behaviour and not UX friendly!

A MVVM message is needed to reposition the LLS through the use of the ScrollTo method

> cfr. code behind of the MainPage.xaml.cs, currently commented out to show that the LLS is positioned at the bottom!
