#!/usr/bin/python
username = 'timbikbaev'
password = ''
url = 'https://somesite.com'
from contextlib import closing
from selenium.webdriver import Firefox # pip install selenium
from selenium.webdriver.support.ui import WebDriverWait

# use firefox to get page with javascript generated content
with closing(Firefox()) as browser:
#  try:
     # First app enter and IAM login
     browser.get(url)
     user_input = browser.find_element_by_name('Ecom_User_ID')
     user_input.send_keys(username)
     pass_input = browser.find_element_by_name('Ecom_Password')
     pass_input.send_keys(password)
     button = browser.find_element_by_name('loginButton2')
     button.click()
     # wait for  IAM auth and FX main page to load
     WebDriverWait(browser, timeout=15).until(
         lambda x: x.find_element_by_id('gwt-debug-sms-contact-selector-button'))

     #checking SMS widget
     page_source = browser.page_source
     phone_box = browser.find_element_by_xpath("//input[@class='gwt-SuggestBox'][@type='text'][@style='width: 50px; padding-left: 33px;']")
     phone_box.clear()
     phone_box.send_keys('+380')
     phone =  browser.find_element_by_xpath("//input[@class='gwt-SuggestBox'][@type='text'][@style='width: 100%;'][@placeholder='Enter phone or contact from address book']")
     phone.send_keys('675113341')
     add_button =  browser.find_element_by_id('gwt-debug-sms-contact-selector-button')
     add_button.click()
     #print browser.find_element_by_xpath("//span[@class='gwt-InlineLabel']").text
     sms_text =  browser.find_element_by_xpath("//textarea[@class='GKX1YBCDHXB'][@placeholder='Enter message']")
     sms_text.send_keys('UIIIIIII FROM FX))))')
     send_button = browser.find_element_by_id('smsButton')
     send_button.click()

     #Second step to check Freight searches
     search = 'https://fx.stage.wkts.eu/freightexchange.html#list:freight-search:'
     browser.get(search)
     WebDriverWait(browser, timeout=15).until(
         lambda x: x.find_element_by_id('gwt-debug-list-toolbar-new'))
     new_button = browser.find_element_by_id('gwt-debug-list-toolbar-new')
     new_button.click()
     WebDriverWait(browser, timeout=15).until(
         lambda x: x.find_element_by_xpath("//select[@class='gwt-ListBox GKX1YBCDIIB GKX1YBCDDW GKX1YBCDAV'][@style='width: 100px;']"))
     from_country = browser.find_element_by_xpath("//select[@class='gwt-ListBox GKX1YBCDIIB GKX1YBCDDW GKX1YBCDAV'][@style='width: 100px;']/option[@value = 'France'][position()=1]")
     from_country.click()
     from_city = browser.find_element_by_xpath("//div[@id='gwt-debug-departure-location']/div[1]/input[1]")
     from_city.send_keys('Toulouse')

     to_country = browser.find_element_by_xpath("//div[@class='GKX1YBCDPU GKX1YBCDAV'][@id='gwt-debug-arrival-location']/select[1]/option[@value = 'France']")
     to_country.click()
     print(from_city.get_attribute('value'))
     to_city = browser.find_element_by_xpath("//div[@id='gwt-debug-arrival-location']/div[1]/input[1]")
     to_city.send_keys('62123, Habarcq, Nord-Pas-de-Calais')
     search_key = browser.find_element_by_id('freightSearchPost')
     search_key.click()
     WebDriverWait(browser, timeout=15).until(
         lambda x: x.find_element_by_xpath("//span[@title='From/To']"))
     fromto = browser.find_element_by_xpath("//span[@title='From/To']")


     #Creating contact
     address_book = 'https://somesite.com/freightexchange.html#contacts:main'
     browser.get(address_book)
     WebDriverWait(browser, timeout=15).until(
         lambda x: x.find_element_by_id('gwt-debug-contact-list-toolbar-new'))
     create_button = browser.find_element_by_id('gwt-debug-contact-list-toolbar-new')
     create_button.click()
     WebDriverWait(browser, timeout=15).until(
         lambda x: x.find_element_by_xpath("//input[@placeholder='Contact name']"))
     name = browser.find_element_by_xpath("//input[@placeholder='Contact name']")
     name.send_keys('test user')
     ph = browser.find_element_by_xpath("//input[@placeholder='+xx']")
     ph.send_keys('+380')
     phone = browser.find_element_by_xpath("//input[@placeholder='xxxxxxxx']")
     phone.send_keys('671014882')
     mail = browser.find_element_by_xpath("//input[@placeholder='email@mail.com']")
     mail.send_keys('timur_bikbaev@epam.com')
     save_button = browser.find_element_by_id('contactSaveButton')
     save_button.click()

     preferences = 'https://somesite.com/freightexchange.html#settings:settings:main'
     browser.get(preferences)
     WebDriverWait(browser, timeout=15).until(
         lambda x: x.find_element_by_xpath("//select[@class='gwt-ListBox']/option[@value='test user']"))
     default_user = browser.find_element_by_xpath("//select[@class='gwt-ListBox']/option[@value='test user']")
     default_user.click()
     save_settings = browser.find_element_by_id('gwt-debug-settings-save-btn')
     save_settings.click()

     post_offer = 'https://somesite.com/freightexchange.html#offer:create'
     browser.get(post_offer)
     WebDriverWait(browser, timeout=15).until(
         lambda x: x.find_element_by_id('gwt-debug-contact-selector'))
     offer_contact = browser.find_element_by_xpath("//div[@id='gwt-debug-contact-selector']/input[1]")
     print(offer_contact.get_attribute('value'))

     #SMS history
     sms_history = 'https://somesite.com/freightexchange.html#smshistory:main'
     browser.get(sms_history)
     WebDriverWait(browser, timeout=15).until(
         lambda x: x.find_element_by_xpath("//table[@cellspacing='0'][@style='table-layout: fixed; width: 100%;']"))
     sms_table = browser.find_element_by_xpath("//table[@cellspacing='0'][@style='table-layout: fixed; width: 100%;']/tbody/tr[1]")
     print(sms_table.text)
#  except Exception,e: print str(e)
