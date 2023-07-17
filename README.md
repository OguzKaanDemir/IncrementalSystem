# IncrementalSystem
It is a Incremental System.

Unity version: 2021.3.2f1

# How to use?
Firstly create a IncrementalItemManager in "Resources" folder.                           
![CreateManager](https://github.com/OguzKaanDemir/IncrementalSystem/assets/80393390/42e04851-e98b-45f2-a4c9-9247de171ec7)

After that add your items.                     
![SetYourItems](https://github.com/OguzKaanDemir/IncrementalSystem/assets/80393390/84085e3d-ec18-4d7e-9a85-16879a872288)

You can add the costs to the "Costs" list or click on "Costs From Custom" to write your customized algorithm inside the "CustomCost" class within the IncrementalItemManager.                         
![SetCostsArrayOrClickCostsFromCustom](https://github.com/OguzKaanDemir/IncrementalSystem/assets/80393390/2e3b428b-d19e-48a0-84a1-f66b0b90ee21)

Create a Canvas and add the "UIButtonHandler" script to it, then customize it as desired.                         
![CreateCanvasWithUIButtonHandler](https://github.com/OguzKaanDemir/IncrementalSystem/assets/80393390/f4da97f8-3eb1-4c3f-b815-8583c6362586)

Add your Buttons from the "Prefabs" folder to the Canvas you created.               
![AddYourButtons](https://github.com/OguzKaanDemir/IncrementalSystem/assets/80393390/cea83912-9350-4de7-b8a6-941f287c8774)

Set the group and item numbers for the buttons you added.          
![SetItemsGorupAndItemNo](https://github.com/OguzKaanDemir/IncrementalSystem/assets/80393390/a3b5b70c-c4ea-40c1-a05e-f6bc9b138daa)

Fill the OnClick events of the buttons with the functions from the script you created. (It has been done with an example script in the video. You can refer to the "Examples" folder for reference.)                        
![SetOnClicks](https://github.com/OguzKaanDemir/IncrementalSystem/assets/80393390/e0c147bc-964c-428f-a1cf-95911053f8f8)

Example CustomCost       
![CustomCost](https://github.com/OguzKaanDemir/IncrementalSystem/assets/80393390/5c9c1b72-178e-402d-9193-a3d5e29386a3)

# Note
Just create "one" IncrementalItemManager.
