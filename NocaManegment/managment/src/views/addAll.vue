<template>
  <div>
    <div>
      <b-card-group columns>
        <b-card class="cabinet" title="ახალი კარადის დამატება">
          <b-form @submit="oncabinet" v-if="show">
            <b-form-group
              id="input-group-1"
              label="კარადის ნომერი:"
              label-for="input-1"
              description="შეგიძლიათ მიუთითოთ მხოლოდ ციფრი"
            >
              <b-form-input
                id="input-1"
                v-model="Cabinet.num"
                type="number"
                required
                placeholder="კარადის ნომერი"
              ></b-form-input>
            </b-form-group>
            <b-button type="submit" variant="primary">შენახვა</b-button>
            <b-card-text class="text-right addshelf">
              <b-button type="button" variant="outline-info" @click="shelf">თაროს დამატება</b-button>
            </b-card-text>
          </b-form>
        </b-card>
        <b-card :class="{Shelfnone : isAddShelf}" class="shelf" title="ახალი თაროს  დამატება">
          <div class="divtest"></div>
          <b-form @submit="onshelf" v-if="show">
            <b-form-group label="აირჩიე კარადა:">
              <b-form-select
                v-model="selected"
                :options="cabinets"
                class="mb-3"
                value-field="item"
                text-field="name"
                disabled-field="notEnabled"
              ></b-form-select>
              <div class="mt-3">
                <!-- არჩეული კარადის ნომერი:
                <strong>{{ selected }}</strong>-->
              </div>
            </b-form-group>
            <b-form-group
              id="input-group-1"
              label="თაროს ნომერი:"
              label-for="input-1"
              description="შეგიძლიათ მიუთითოთ მხოლოდ ციფრი"
            >
              <b-form-input
                id="input-1"
                v-model="Cabinet.num"
                type="number"
                required
                placeholder="თაროს ნომერი"
              ></b-form-input>
            </b-form-group>
            <b-button type="submit" variant="primary">შენახვა</b-button>
            <b-card-text class="text-right addshelf">
              <b-button
                type="button"
                @click="product"
                variant="outline-info"
                class
              >პროდუცტის დამატება</b-button>
            </b-card-text>
          </b-form>
        </b-card>

        <b-card :class="{Shelfnone: isAddProduct}" class="product" title="ახალი პროდუცტის დამატება">

          <b-form @submit="onProduct" v-if="show">

            <b-form-group label="აირჩიე თარო:">
              <b-form-select
                v-model="selectedpro"
                :options="productList"
                class="mb-3"
                value-field="item"
                text-field="name"
                disabled-field="notEnabled"
              ></b-form-select>
            </b-form-group>

            <b-form-group
              id="input-group-1"
              label=" პროდუცტის კოდი:"
              label-for="input-1"
              description="შეგიძლიათ მიუთითოთ მხოლოდ ციფრი"
            >
              <b-form-input
                id="input-1"
                v-model="Cabinet.num"
                type="number"
                required
                placeholder="პროქტის კოდი"
              >
              </b-form-input>

            </b-form-group>

               <b-form-group
              id="input-group-1"
              label="პროდუცტის სახელი:"
              label-for="input-1"
              
            >

              <b-form-input
                id="input-1"
                v-model="Cabinet.num"
                type="text"
                required
                placeholder="პროდუცტის სახელი"
              >
              </b-form-input>

            </b-form-group>


               <b-form-group
              id="input-group-1"
              label="პროდუქტის ფასი:"
              label-for="input-1"
              description="შეგიძლიათ მიუთითოთ მხოლოდ ციფრი"
              
            >
              <b-form-input
                id="input-1"
                v-model="Cabinet.num"
                type="text"
                required
                placeholder="პროდუქტის ფასი"
              ></b-form-input>
            </b-form-group>
            
               <b-form-group
              id="input-group-1"
              label="პროდუქტის წონა:"
              label-for="input-1"
              
            >
              <b-form-input
                id="input-1"
                v-model="Cabinet.num"
                type="text"
                required
                placeholder="პროდუქტის წონა"
              ></b-form-input>
            </b-form-group>
            <b-button type="submit" variant="primary">შენახვა</b-button>
          </b-form>
        </b-card>
      </b-card-group>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      isAddShelf: true,
      isAddProduct: true,
      Cabinet: {
        num: null,
      },

      form: {
        email: "",
        name: "",
        food: null,
        checked: [],
      },
      selected: "A",
      selectedpro:"",
      cabinets: [{ item: "A", name: "Option A" }],
      productList: [{ item: "A", name: "Option A" }],
      show: true,
    };
  },
  methods: {
    oncabinet(evt) {
      this.isAddShelf = true;
      evt.preventDefault();
      alert(JSON.stringify(this.Cabinet));
    },
    onshelf(evt) {
      this.isAddProduct = true;
      evt.preventDefault();
      alert(JSON.stringify(this.Cabinet));
    },
    onProduct(evt) {
      evt.preventDefault();
      alert(JSON.stringify(this.Cabinet));
    },

    product() {
    this.isAddProduct = !this.isAddProduct;
    this.productList = [];
        axios
          .get(`http://localhost:64166/Home/Shelfeslist`)
          .then((response) => {
            console.log(response.data);
            for (var i = 0; i < response.data.length; i++) {
              this.productList.push({
                item: response.data[i].id,
                name: "თარო"+ response.data[i].num,
              });
            }
          })
          .catch((e) => {
            console.log(e);
          });
    },
    shelf() {
      this.isAddShelf = !this.isAddShelf;
      this.isAddProduct = true;
      (this.cabinets = []),
        axios
          .get(`http://localhost:64166/Home/Cabinets`)
          .then((response) => {
            for (var i = 0; i < response.data.length; i++) {
              this.cabinets.push({
                item: response.data[i].id,
                name: "კარადა" + response.data[i].num,
              });
            }
          })
          .catch((e) => {
            console.log(e);
          });
    },
  },
};
</script>

<style>
.divtest {
  position: absolute;
  height: 50px;
  width: 50px;
  background-color: #007bff75;
  border-radius: 50%;
  margin-left: 18px;
  margin-top: 220px;
  z-index: -99;
}
.addshelf {
  margin-right: -21px;
}
.cabinet {
  margin-top: 20px;
  margin-left: 15px;
  box-shadow: -4px -1px 3px 0px #007bff;
}

.shelf {
  margin-top: 257px;
  margin-left: 0px;
  z-index: 99;
  box-shadow: -2px -1px 3px 0px #17a2b8;
}
.Shelfnone {
  display: none !important;
}
body {
  z-index: 99;
}
</style>