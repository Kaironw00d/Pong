using System;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<Tab> tabs;
    public List<TabContent> tabsContent;

    private int _defaultTabIndex = -1;
    private int _selectedTabIndex;

    private void Awake()
    {
        for (var i = 0; i < tabs.Count; i++)
        {
            if(_defaultTabIndex < 0)
                _defaultTabIndex = tabs[i].isDefaultTab ? tabs[i].tabIndex : -1;
            
            tabs[i].OnPointerClicked += OnTabSelected;
        }
    }

    private void OnEnable() => ShotTabContent(_defaultTabIndex);

    private void OnTabSelected(int tabIndex)
    {
        if(tabIndex == _selectedTabIndex) return;

        _selectedTabIndex = tabIndex;
        ShotTabContent(tabIndex);
    }

    private void ShotTabContent(int index)
    {
        for (var i = 0; i < tabsContent.Count; i++)
        {
            var tabContent = tabsContent[i];
            tabContent.gameObject.SetActive(tabContent.tabContentIndex == index);
        }
    }

    private Tab GetTab(int index)
    {
        for (var i = 0; i < tabs.Count; i++)
        {
            var tab = tabs[i];
            if (tab.tabIndex == index)
                return tab;
        }
        
        return null;
    }

    private TabContent GetTabContent(int index)
    {
        for (var i = 0; i < tabsContent.Count; i++)
        {
            var tabContent = tabsContent[i];
            if (tabContent.tabContentIndex == index)
                return tabContent;
        }
        
        return null;
    }
}
