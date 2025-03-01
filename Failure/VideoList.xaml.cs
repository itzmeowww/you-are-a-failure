﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace you_are_a_failure.Failure;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class VideoList : Page
{
    public static Action<string> OnListViewClickHandler { get; set; }

    public VideoList()
    {
        this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        Array.ForEach(
            Classes.Steven.VideoList,
            video => VideoListView.Items.Add(new TextBlock { Text = video.FileName })
        );

        base.OnNavigatedTo(e);
    }

    private void VideoListView_ItemClick(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is not TextBlock clicked) return;

        if (OnListViewClickHandler is not null)
        {
            OnListViewClickHandler(clicked.Text);
        }
    }
}
