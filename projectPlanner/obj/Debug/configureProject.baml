   M S B A M L   `   `   `  ����I  EprojectPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:projectPlannerprojectPlanner  5   	   %    projectPlanner.configureProject   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:projectPlanner     5   	   e aSyncfusion.SfSchedule.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.SfGrid.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Linq.Base, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b	 ^Syncfusion.SfInput.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89`
 \Syncfusion.Tools.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfChart.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89e aSyncfusion.GridCommon.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89g cSyncfusion.SfRadialMenu.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSpreadsheet.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89e aSyncfusion.SfCellGrid.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89_ [Syncfusion.Grid.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89H
syncfusion!http://schemas.syncfusion.com/wpf    	 
        5   	   -   5          � Title$  configureProject��5	   	   $	��450��6"   $	��800��6/    � 	Resources 5
      *   $projectPlanner.projectPlannerDataSet   projectPlannerDataSet  teamMembersViewSource �� Source �� Source  taskViewSource  projectViewSource  projectMangerViewSource��%  &	        &	      7   &	 D     7   &	 n     7   &	 �     7     5   
   6&   �� 5   
    6=   �� *teamMembers+8   �� 5   
    66   �� *task+8   �� 5   
    69   �� *	project+8   �� 5   
    6?   �� *projectManger+8   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��29* �6   �� 5      $
��390* �6   .+�5   
   �� $
��Left=�6   $	��398��60   $��0,2,0,0q�6=   $	��Top=�6N   $	��786��6f   $��2��6r   .@�5      �� $��project Tasks��6   .��5      � ���	#FFE5E5E5 � DataContext# [ 6.   .+�5      �� $
��Left=�6   $	��100��68   $��400,167,0,0q�6E   $	��Top=�6Z   $	��100��6r   �� 5      -   5         ��Name$ taskName��5      $
��Left=�60   $��33��6K   $��
53,290,0,0q�6W    �� TextWrapping$ NoWrap=�6k   $	��Top=�6�   $��84��6�   �� 5      -   5        $ taskDuration��5      $
��Left=�64   $��34��6O   $��181,288,0,0q�6[   $ NoWrap=�6p   $	��Top=�6�   $��84��6�   �� 5      -   5        $��nameS��5      $�� Name��6)   $
��Left=�69   $��27��6T   $��
53,262,0,0q�6`   $	��Top=�6t   $��80��6�   �� 5      -   5        $��	duratiobS��5      $��Duration��6-   $
��Left=�6@   $��27��6[   $��183,260,0,0q�6g   $	��Top=�6|   $��84��6�   �� 5      -   5        $��startS��5      $��
start Date��6*   $
��Left=�6?   $��26��6Z   $��324,260,0,0q�6f   $	��Top=�6{   $��88��6�   �� 5      -   5        $
��endS��5      $��end Date��6(   $
��Left=�6;   $��25��6V   $��453,260,0,0q�6b   $	��Top=�6w   $��98��6�   &   System.Windows.Controls.DataGrid  5       -   5        $��taskGrid��5        $
��Left=�60   $	��191��6K   $��	25,20,0,0q�6X   $	��Top=�6k   $	��705��6�   ��6�   �� �� 5!      -	   5        $��Add Task��5!      $
��Left=�60   $��33��6K   $��628,322,0,0q�6W   $	��Top=�6l   $	��100��6�   6�   �� 5"      -
   5         ��Name$ 	isSubTask��5"      $��
Is Subtask��62   $
��Left=�6G   $��19��6b   $��534,335,0,0q�6n   $	��Top=�6�   $��85��6�   6�   4 	 .Syncfusion.Windows.Controls.Input.SfDatePicker  5#      -   5        $��taskStartDate��5#   .   $
��Left=�6C   $��31��6^   $��311,289,0,0q�6j   $	��Top=�6   $��97��6�     5$      -   5        $��taskEndDate��5$   .   $
��Left=�6A   $��32��6\   $��444,288,0,0q�6h   $	��Top=�6}   $��97��6�   �� 5%      -   5        $��isPredessecor��5%      $��has Predessecor��64   $
��Left=�6N   $��18��6i   $��398,335,0,0q�6u   $	��Top=�6�   $	��110��6�   6�   �� 5&      -   5        $��parentId_box��5&      $y�Hidden=�62   $
��Left=�6F   $��37��6a   $��625,274,0,0q�6m   $ NoWrap=�6�   $�� ��6�   $	��Top=�6�   $	��107��6�   �� 5'      -   5        $��parentId_label��5'      $��	parent ID��62   $y�Hidden=�6F   $
��Left=�6Z   $��32��6u   $��548,278,0,0q�6�   $	��Top=�6�   $��70��6�   5(      5)      �� 5*      $��project members ��6   .��5+      � ���	#FFE5E5E5# [ 6.   $��	2,3,-2,-3q�6c   .+�5,      �� -   5        $ titleM��5,      $
��Left=�6.   $��32��6I   $��	65,43,0,0q�6U   $ NoWrap=�6h   $�� ��6~   $	��Top=�6�   $	��100��6�   6�   �� 5-      -   5        $ hoursPerDayM��5-      $
��Left=�64   $��30��6O   $��
65,100,0,0q�6[   $ NoWrap=�6o   $�� ��6�   $	��Top=�6�   $	��100��6�   �� 5.      -   5        	 ��Name$	 Addmember_button��5.      $��
Add member��67   $
��Left=�6L   $��36��6g   $��
34,163,0,0q�6s   $	��Top=�6�   $	��141��6�   6�     5/      -   5        $��taskGridmember��5/      $
��Left=�65   $	��271��6P   $��
197,37,0,0q�6]   $	��Top=�6q   $	��535��6�   ��6�   �� �� 50      -   5        $��titleS��50      $��title��6*   $
��Left=�6:   $��33��6U   $��	11,43,0,0q�6a   $	��Top=�6t   $��40��6�   �� 51      -   5        $��hrDay��51      $��hr/Day��6)   $
��Left=�6:   $��27��6U   $��9,90,0,0q�6a   $	��Top=�6s   $��49��6�   �� 52      -   5        $ assign_memberId_box��52   2   $y�Hidden=�6   $
��Left=�6O   $��33��6j   $��568,325,0,0q�6v   $ NoWrap=�6�   $�� ��6�   $	��Top=�6�   $��96��6�   �� 53      -   5        $ assign_taskid_box��53   2   $y�Hidden=�6   $
��Left=�6M   $��30��6h   $��295,328,0,0q�6t   $ NoWrap=�6�   $�� ��6�   $	��Top=�6�   $��94��6�   �� 54      -   5        
 ��Name$
 assign_taskId��54   0   $y�Hidden=�6   $��Enter task ID��6G   $
��Left=�6_   $��31��6z   $��195,327,0,0q�6�   $	��Top=�6�   $��84��6�   �� 55      -   5        $
 assign_memberId��55   0   $y�Hidden=�6   $��Enter team member ID��6I   $
��Left=�6h   $��31��6�   $��414,328,0,0q�6�   $	��Top=�6�   $	��140��6�   �� 56      -   5        $	 assigen_hr_button��56      $��Assign Human Resource��68   $
��Left=�6X   $��34��6s   $��
37,241,0,0q�6   $	��Top=�6�   $	��138��6�   6�   �� 57      -   5        $	 assign_save_box��57   1   $y�Hidden=�6   $
��save��6J   $
��Left=�6Y   $��28��6t   $��696,327,0,0q�6�   $	��Top=�6�   $��68��6�   6�   58      59      5;      5=      5>      