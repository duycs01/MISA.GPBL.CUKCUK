import { createApp } from 'vue'
import Vue from 'vue'
import App from './App.vue'
import router from './router'
import "./assets/css/main.css";
import Language from "./resources/language/vie";
import Enum from "./utils/enum";
import FormatData from "./utils/format";

import MenuApi from "./apis/components/Menu";
import UnitApi from "./apis/components/Unit";
import MenuGroupApi from "./apis/components/MenuGroup";
import ServiceHobbyApi from "./apis/components/ServiceHobby";
import ProcessingApi from "./apis/components/Processing";

import MenuModel from "./Model/menu";
import UnitModel from "./Model/unit";
import MenuGroupModel from "./Model/menuGroup";
import ServiceHobbyModel from "./Model/serviceHobby";
import ProcessingModel from "./Model/processing";
import OrderOfDishesModel from "./Model/orderOfDishes";
import TypeOfMenuModel from "./Model/typeOfMenu";
import ValidateData from "./utils/validate";

import InputPaging from "./Model/inputPaging";


import mitt from 'mitt';
const emitter = mitt();

import {
    Select,
    Button,
    Input,
    Pagination,
    Menu,
    Col,
    Row,
    Divider,
    Table,
    Form,
    InputNumber,
    Tag,
    Checkbox,
} from 'ant-design-vue';

const app = createApp(App);
app.config.productionTip = false;
app.use(Select);
app.use(Button);
app.use(Input);
app.use(Pagination);
app.use(Checkbox);
app.use(Menu);
app.use(Col);
app.use(Row);
app.use(Divider);
app.use(Table);
app.use(Form);
app.use(InputNumber);
app.use(Tag);

app.config.globalProperties.$Language = Language
app.config.globalProperties.$Enum = Enum
app.config.globalProperties.$FormatData = FormatData

app.config.globalProperties.$MenuApi = MenuApi
app.config.globalProperties.$MenuGroupApi = MenuGroupApi
app.config.globalProperties.$UnitApi = UnitApi
app.config.globalProperties.$ServiceHobbyApi = ServiceHobbyApi
app.config.globalProperties.$ProcessingApi = ProcessingApi

app.config.globalProperties.$MenuModel = MenuModel
app.config.globalProperties.$MenuGroupModel = MenuGroupModel
app.config.globalProperties.$UnitModel = UnitModel
app.config.globalProperties.$ServiceHobbyModel = ServiceHobbyModel
app.config.globalProperties.$ProcessingModel = ProcessingModel
app.config.globalProperties.$OrderOfDishesModel = OrderOfDishesModel
app.config.globalProperties.$TypeOfMenuModel = TypeOfMenuModel
app.config.globalProperties.$InputPaging = InputPaging
app.config.globalProperties.$ValidateData = ValidateData


app.config.globalProperties.emitter = emitter;

app.use(router);
app.mount('#app');


