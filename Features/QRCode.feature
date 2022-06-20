Feature: QRCode


Scenario Outline: Text encoding and qr-code reading
	Given following link was opened: http://qrcoder.ru/
	Then website for generating QR codes with text Генератор QR кодов has been opened
	When user in the закодировать item, clicks on the text ссылку на сайт
	Then website for generating QR codes with text Ссылка на сайт в виде QR кода has been opened
	When user enteres text <url> in the url-field and clicks создать код button
	Then picture with QR-code appeared in special block
	Then user compares received url from QR-code with original link <url>

Examples: 
	| url                   |
	| https://www.a1qa.com/ |