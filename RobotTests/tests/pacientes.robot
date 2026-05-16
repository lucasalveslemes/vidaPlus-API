*** Settings ***
Library    RequestsLibrary
Library    Collections
Resource   ../resources/variables.robot
Resource   ../resources/api.robot

*** Test Cases ***
CT-01 Login deve retornar token JWT
    Criar Sessão
    ${token}=    Fazer Login
    Should Not Be Empty    ${token}
    Log    Token obtido: ${token}

CT-02 Deve criar um paciente com sucesso
    Criar Sessão
    Fazer Login
    ${headers}=    Obter Header Com Token
    ${body}=    Create Dictionary
    ...    nome=Robot Paciente
    ...    email=robot@vidaplus.com
    ...    cpf=98765432100
    ...    telefone=31911111111
    ...    endereco=Rua Robot, 1
    ...    dataNascimento=1995-01-01T00:00:00
    ...    observacoes=Criado pelo Robot Framework
    ${response}=    POST On Session    vidaplus    /api/pacientes
    ...    json=${body}    headers=${headers}
    Should Be Equal As Integers    ${response.status_code}    201
    ${id}=    Set Variable    ${response.json()['id']}
    Set Global Variable    ${PACIENTE_ID}    ${id}
    Log    Paciente criado com ID: ${id}

CT-03 Deve listar pacientes
    Criar Sessão
    Fazer Login
    ${headers}=    Obter Header Com Token
    ${response}=    GET On Session    vidaplus    /api/pacientes
    ...    headers=${headers}
    Should Be Equal As Integers    ${response.status_code}    200
    ${lista}=    Set Variable    ${response.json()}
    Should Not Be Empty    ${lista}
    Log    Total de pacientes: ${lista.__len__()}

CT-04 Deve rejeitar CPF inválido
    Criar Sessão
    Fazer Login
    ${headers}=    Obter Header Com Token
    ${body}=    Create Dictionary
    ...    nome=Teste Inválido
    ...    email=invalido@robot.com
    ...    cpf=123.456.789-00
    ...    telefone=31999999999
    ...    endereco=Rua Teste, 1
    ...    dataNascimento=1990-01-01T00:00:00
    ...    observacoes=Teste negativo
    ${response}=    POST On Session    vidaplus    /api/pacientes
    ...    json=${body}    headers=${headers}
    ...    expected_status=400
    Should Be Equal As Integers    ${response.status_code}    400
    Log    API rejeitou CPF inválido corretamente