*** Settings ***
Library    RequestsLibrary
Library    Collections
Resource   variables.robot

*** Keywords ***
Criar Sessão
    Create Session    vidaplus    ${BASE_URL}    verify=False

Fazer Login
    ${body}=    Create Dictionary    email=${EMAIL}    senha=${SENHA}
    ${response}=    POST On Session    vidaplus    /api/auth/login    json=${body}
    ${TOKEN}=    Set Variable    ${response.json()['token']}
    Set Global Variable    ${TOKEN}
    RETURN    ${TOKEN}

Obter Header Com Token
    ${headers}=    Create Dictionary    Authorization=Bearer ${TOKEN}
    RETURN    ${headers}