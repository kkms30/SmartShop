﻿<Window x:Class="SmartShopWpf.OknoLogowania"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:SmartShopWpf"
        mc:Ignorable="d"
        ResizeMode="NoResize"
        Title="OknoLogowania" Height="729" Width="1131">

    <Grid Height="698" VerticalAlignment="Bottom" HorizontalAlignment="Left" Width="1123" Background="{StaticResource Obramowanie}">

        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Label  x:Name="lblLogowanie"    HorizontalAlignment="Left" VerticalAlignment="Top" Height="73"  Width="999"  Margin="60,37,0,0" Background="{StaticResource Pomaranczowy}" BorderThickness="1,1,1,1" BorderBrush="{StaticResource Bialy}" Content="Logowanie" Style="{StaticResource LblFont36}" HorizontalContentAlignment="Center" VerticalContentAlignment="Center"/>

        <TextBox x:Name="txtLogin"     HorizontalAlignment="Left" VerticalAlignment="Top" Height="55" Width="301" Margin="413,310,0,0"  Background="{StaticResource Pomaranczowy}" BorderThickness="1,1,1,1" BorderBrush="{StaticResource Bialy}" Style="{StaticResource TxtFont26}" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" />
        <TextBox x:Name="txtHaslo"     HorizontalAlignment="Left" VerticalAlignment="Top" Height="55" Width="301" Margin="413,364,0,0"  Background="{StaticResource Pomaranczowy}" BorderThickness="1,1,1,1" BorderBrush="{StaticResource Bialy}" Style="{StaticResource TxtFont26}" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" />


        <Button x:Name="btnZaloguj"               HorizontalAlignment="Left" VerticalAlignment="Top" Height="55" Width="301" Margin="413,418,0,0" Background="{StaticResource Czerwony}"      BorderThickness="1,1,1,1" BorderBrush="{StaticResource Bialy}"  Content="Zaloguj"         Style="{StaticResource BtnFontRed30}"   HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Click="btnZaloguj_Click"/>

        <Label  x:Name="lblBladLogowania"         HorizontalAlignment="Left" VerticalAlignment="Top" Height="55" Width="301" Margin="413,474,0,0" Background="{StaticResource Czarny}"        BorderThickness="1,1,1,1" BorderBrush="{StaticResource Czarny}" Content="Blad Logowania!" Style="{StaticResource LblFont30}"   HorizontalContentAlignment="Center" Foreground="{StaticResource Czerwony}" Visibility="Hidden"/>
             
    </Grid>
</Window>
