   M S B A M L   `   `   `  ����	  Пр4    Пр4.RegisterWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Регистрация��5   	   $	��392��6   $	��300��6*    � WindowStartupLocation$ CenterScreen=�66   ��5      �� 5	   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5
      �  � Color$ 	#FF525D73��6    � Offset$
 0.36Q�6-   � 5      $ 	#FFD2CCE0��6   $
 0.82Q�6-   5      .��5      �� $	��Top=�6   $��Center=�6)   $	��342��6F   $��0,10,0,0q�6S   .+�5   
   �� $ ��Введите логин:��6   $��56,0,0,0q�6*   $��Italic$�6<   �� 5   
   -   5         ��Name$ LoginBox��5      $��Center=�6$   $	��Top=�6A   $��0,0,0,0q�6Y   $	��168��6j   ���	#FF153EC36v   �� 5   
   $"��Введите пароль:��6   $��	-18,0,0,0q�6*   $��Italic$�6=   $	��144��6P   G� 5   
   -   5         G�Name$ PasswordBox��5      $	��168��6+   ���	#FF153EC3 J� RenderTransformOrigin$ 0.589,10.143&�6O   �� 5   
   $0��*Введите пароль ещё раз:��6   $��
-15,10,0,0q�62   $��Italic$�6F   $	��148��6Y   $��27��6e   G� 5   
   -   5        $ PasswordBox2��5      $��Center=�6,   $	��Top=�6I   $��0,0,0,0q�6a   $	��168��6r   ���	#FF153EC36~   �� 5   
   -   5        	 ��Name$	 ErrorMessageTextBlock��5      
���  ��$	��280��6D   $
��Wrap=�6P   �� 5   
   -   5        $*��$Зарегистрироваться��5      $	��142��6K   ���	#FF4C4D56���	#FF5068F1���	#FF88B0F1
 J� IsManipulationEnabled
 . $
��Bold"�6�   $��25��6�   �� 5   
   -   5        $��Меню��5      $��0,10,0,0q�65   ���	#FF88B0F1���	#FF5068F1���	#FF524444$��93��6�   $
��Bold"�6�   $��Center=�6�   $��25��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      5      5#      