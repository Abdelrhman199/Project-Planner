   M S B A M L   `   `   `  ����I  EprojectPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:projectPlannerprojectPlanner  5   	   "    projectPlanner.createProject   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:projectPlanner     5   	   e aSyncfusion.SfSchedule.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.SfGrid.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Linq.Base, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b	 ^Syncfusion.SfInput.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89`
 \Syncfusion.Tools.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfChart.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89e aSyncfusion.GridCommon.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89g cSyncfusion.SfRadialMenu.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSpreadsheet.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89e aSyncfusion.SfCellGrid.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89_ [Syncfusion.Grid.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89H
syncfusion!http://schemas.syncfusion.com/wpf    	 
        5   	   -   5          � Title$  createProject��5	   	   $	��385��6   $	��835��6,    � 	Resources 5
      *   $projectPlanner.projectPlannerDataSet   projectPlannerDataSet  projectViewSource �� Source �� Source��%X   &	        &	      7     5   
   6&   �� 5   
    69   �� *	project+8   5      .��5      � $��0,0,12,4q�6    � DataContext# [ 6   .+�5   
   �� -   5         ��Name$ projectName��5      $
��Left=�6'   $��23��6B   $��
18,239,0,0q�6N    �� TextWrapping$ NoWrap=�6b   $�� ��6x   $	��Top=�6�   $	��125��6�   �� 5   
   -   5        $ projectCost��5      $
��Left=�6(   $��26��6C   $��179,241,0,0q�6O   $ NoWrap=�6d   $�� ��6z   $	��Top=�6�   $	��146��6�   �� 5   
   -   5        $��logout��5      $
��Left=�6"   $��35��6=   $��487,299,0,0q�6I   $	��Top=�6^   $	��134��6v   6�   �� 5   
   $��project name��6   $
��Left=�6'   $��29��6B   $��
34,202,0,0q�6N   $	��Top=�6b   $��87��6z   �� 5   
   $��project cost��6   $
��Left=�6'   $��26��6B   $��194,201,0,0q�6N   $	��Top=�6c   $	��102��6{   �� 5   
   $��
start date��6   $
��Left=�6%   $��27��6@   $��387,196,0,0q�6L   $	��Top=�6a   $	��128��6y   �� 5   
   $��	end date ��6   $
��Left=�6$   $��25��6?   $��577,192,0,0q�6K   $	��Top=�6`   $	��122��6x   4 	 .Syncfusion.Windows.Controls.Input.SfDatePicker  5   
   -   5        $��	startDate��5   #   $
��Left=�64   $��39��6O   $��382,230,0,0q�6[   $	��Top=�6p   $	��129��6�     5   
   -   5        $��dueDate��5   #   $
��Left=�63   $��38��6N   $��570,231,0,0q�6Z   $	��Top=�6o   $	��128��6�   �� 5   
   -   5        $��create��5      $
��Left=�6"   $��30��6=   $��
93,307,0,0q�6I   $	��Top=�6]   $��81��6u   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��GridProject��5      $
��Left=�6&   $	��183��6A   $��	20,10,0,0q�6N   $	��Top=�6a   $	��787��6y   ��6�   �� �� 5   
   -	   5        $��proceed��5      $
��Left=�6#   $��31��6>   $��311,307,0,0q�6J   $	��Top=�6_   $��90��6w   6�   5      5      